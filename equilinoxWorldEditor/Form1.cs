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
                            if(item.id != 0)
                                listBox1.Items.Add(item.blueprintName + ": " + item.id);

                            listBox1.Sorted = true;
                        }



                        foreach (JProperty property in jarray)
                        {
                            //Search for control with the same name as the Key + Value
                            Control[] control = groupBox1.Controls.Find(property.Name+"Value", false);
                            
                            if(control.Length > 0)
                            {
                                //Set control text to World Key Value
                                control[0].Text = property.Value.ToString();

                            }


                        }


                    }
                }
            }


            



        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //Open DialogBox
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "JSON files|*.json";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Write all of the serialized json data into a new file
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(jarray));
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            propPanel.Visible = true;

            var itemName = listBox1.GetItemText(listBox1.SelectedItem);

            for (int i = 0; i < ((ICollection)jarray.entities).Count; i++)
            {
                //Check if the current loops blueprintName is the same as the selected one 
                if (jarray.entities[i].blueprintName+": "+ jarray.entities[i].id == itemName)
                {
                    //Loop through all of the Properites in the entities object (For Key and Key Value)
                    foreach (JProperty property in jarray.entities[i])
                    {
                        //Look for the control that is associated with the current selected entitys values
                        Control[] control = propPanel.Controls.Find(property.Name + "Value", false);
                        if (control.Length > 0)
                        {
                            //Check if control is a CheckBox
                            if (control[0] is CheckBox)
                            {
                                //If so change Checked value since CheckBox check can't be change via text
                                ((CheckBox)control[0]).Checked = (bool)property.Value;
                            }
                            else
                            {
                                //Set Input to be Entity Key Value
                                control[0].Text = property.Value.ToString();
                            }

                        }

                    }
                    break;
                }
            }



        }
    }
}
