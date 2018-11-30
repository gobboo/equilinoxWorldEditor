using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using equilinoxWorldEditor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace equilinoxWorldEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void editEnt(string property, string newValue)
        {


        }

        dynamic jarray;

        private Control FindControlByName(string name)
        {
            foreach (Control c in groupBox1.Controls) //assuming this is a Form
            {
                if (c.Name == name)
                    Console.WriteLine("Found");
                    return c; //found
            }
            Console.WriteLine("Not found");
            return null; //not found
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            var contents = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    using (StreamReader r = File.OpenText(filePath))
                    {
                        string json = r.ReadToEnd();
                        jarray = JObject.Parse(json);



                        //Entities


                        
                        foreach (var item in jarray.entities)
                        {
                            listBox1.Items.Add(item.id.ToString());
                        }



                        foreach (JProperty property in jarray)
                        {

                            Console.WriteLine("Searching for : " + property.Name + "Value");
                            Control[] control = groupBox1.Controls.Find(property.Name+"Value", false);
                            //Console.WriteLine(property.Name + "Value");
                            
                            if(control.Length > 0)
                            {
                                control[0].Text = property.Value.ToString();
                               // Console.WriteLine(control.Name);

                            }


                        }


                        // dpValue.Value = jarray.dp;
                        // dpPerMinValue.Value = jarray.dpPerMin;

                        //World Properties

                    }
                }
            }

            //dynamic array = parseJson.getJson(filePath);

            



        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "JSON files|*.json";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(jarray));
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            propPanel.Visible = true;

            for(int i = 0; i < ((ICollection)jarray.entities).Count; i++)
            {
                if(jarray.entities[i].id == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    //idValue.Value = jarray.entities[i].id;
                    //blueprintValue.Value = jarray.entities[i].blueprintID;
                    //isDeadValue.Checked = jarray.entities[i].isDead;


                    foreach (JProperty property in jarray)
                    {

                        Console.WriteLine("Searching for : " + property.Name + "Value");
                        Control[] control = panel1.Controls.Find(property.Name + "Value", false);
                        //Console.WriteLine(property.Name + "Value");

                        if (control.Length > 0)
                        {
                            control[0].Text = property.Value.ToString();
                            // Console.WriteLine(control.Name);

                        }


                    }
                    break;
                }
            }



        }
    }
}
