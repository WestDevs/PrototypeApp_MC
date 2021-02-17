namespace WEST.Api.Entities
{
    public class LearnerGroup
    {
        public int LearnerId { get; set; }
        public int GroupId { get; set; }

        // Navigation Property
        public Learner Learner { get; set; }
        public Group Group { get; set; }
    }
}