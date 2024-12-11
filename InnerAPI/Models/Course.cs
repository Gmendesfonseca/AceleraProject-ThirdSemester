using System; 

namespace InnerAPI.Models
{
    public class Course
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }

        public Course(uint id, string name, string description, int credits)
        {
            Id = id;
            Name = name;
            Description = description;
            Credits = credits;
        }
    }
}
