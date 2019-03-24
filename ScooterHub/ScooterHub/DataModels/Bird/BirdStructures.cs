using System.Collections.Generic;

namespace ScooterHub.DataModels.Bird
{
    // Bird Auth API
    public class BirdAuth
    {
        public string id { get; set; }
        public string token { get; set; }
    }


    // Main Bird API
    public class BirdAPI
    {
        public List<Bird> birds { get; set; }
        public List<object> clusters { get; set; }
        public List<object> areas { get; set; }
    }

    public class Bird
    {
        public string id { get; set; }
        public Location location { get; set; }
        public string code { get; set; }
        public bool captive { get; set; }
        public int battery_level { get; set; }
        public string nest_id { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}