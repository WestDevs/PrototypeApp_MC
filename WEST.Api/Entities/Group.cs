using System.Collections.Generic;

namespace WEST.Api.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<LearnerGroup> LearnerGroups { get; set; }

    }
}