using System.Collections.Generic;

namespace AGLDevTestAPI.Model
{
    public class Pet
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class PetModel
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pet> pets { get; set; }
    }

    public class PetNamesbyOwnerGender
    {
        public string gender { get; set; }
        public List<string> petnames { get; set; }
    }
}
