using System.Collections.Generic;

namespace WEST.Api.Entities
{
    public class Learner
    {
        public int LearnerId { get; set; }
        public int UserId { get; set; }


        //Navigation Property
        public ICollection<LearnerCourse> LearnerCourses { get; set; }
        public LearnerGroup LearnerGroup { get; set; }
        public AppUser User { get; set; }

        // public Learner()
        // {
        //     this.Courses = new HashSet<Course>();
        // }

    }
}