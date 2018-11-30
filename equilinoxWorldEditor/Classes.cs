using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equilinoxWorldEditor
{
    public class worldData
    {
        public Component Component { get; set; }
        public Entity Entity { get; set; }
        public Task Task { get; set; }
        public RootObject Root { get; set; }
    }

    public class Component
    {
        public double posX { get; set; }
        public double posY { get; set; }
        public double posZ { get; set; }
        public int rotX { get; set; }
        public double rotY { get; set; }
        public int rotZ { get; set; }
        public string name { get; set; }
        public List<object> traits { get; set; }
        public int? currentStage { get; set; }
        public int? parent { get; set; }
        public double? enviromentSatisfaction { get; set; }
        public double? wellBeing { get; set; }
        public double? health { get; set; }
        public double? age { get; set; }
        public int? damagePoints { get; set; }
        public double? lifeExpectancy { get; set; }
        public bool? sufferingDisease { get; set; }
        public int? diseaseDamage { get; set; }
        public bool? breedingBoost { get; set; }
        public double? nextBreedTime { get; set; }
        public int? generation { get; set; }
        public bool? evolutionCompleate { get; set; }
        public int? childSpeciesID { get; set; }
        public bool? fullyGrown { get; set; }
        public int? stageNumber { get; set; }
        public double? totalStageTime { get; set; }
        public double? currentStateTime { get; set; }
    }

    public class Entity
    {
        public bool isDead { get; set; }
        public int blueprintID { get; set; }
        public bool isStatic { get; set; }
        public int id { get; set; }
        public List<Component> components { get; set; }
    }

    public class Task
    {
        public int id { get; set; }
        public bool repeated { get; set; }
        public bool autoCollect { get; set; }
        public bool notifyCollect { get; set; }
        public bool pinned { get; set; }
        public bool complete { get; set; }
        public bool locked { get; set; }
        public List<object> taskRequs { get; set; }
    }

    public class RootObject
    {
        public bool corrupt { get; set; }
        public long lastPlayed { get; set; }
        public int tasksCompleated { get; set; }
        public int population { get; set; }
        public int dp { get; set; }
        public double cameraPosX { get; set; }
        public double cameraPosY { get; set; }
        public double cameraPosZ { get; set; }
        public double cameraYaw { get; set; }
        public double cameraPitch { get; set; }
        public int dp2 { get; set; }
        public int dpPerMin { get; set; }
        public int day { get; set; }
        public double time { get; set; }
        public List<int> unlockedBlueprints { get; set; }
        public double nextMutationTime { get; set; }
        public List<object> evolveProcesses { get; set; }
        public int entityGridNextId { get; set; }
        public List<Entity> entities { get; set; }
        public int seed { get; set; }
        public int smoothness { get; set; }
        public int vertexCount { get; set; }
        public int waterHeight { get; set; }
        public List<object> items { get; set; }
        public List<Task> tasks { get; set; }
    }
    
}
