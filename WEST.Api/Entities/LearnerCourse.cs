namespace WEST.Api.Entities
{
    public class LearnerCourse
    {
        public int LearnerId { get; set; }
        public int CourseId { get; set; }

        // Navigation Property
        public Learner Learner { get; set; }
        public Course Course { get; set; }
    }
}