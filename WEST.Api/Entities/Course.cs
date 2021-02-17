using System.Collections.Generic;

namespace WEST.Api.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }

        //NavigationProperty
        public ICollection<LearnerCourse> LearnerCourses { get; set; }
        
    }
}