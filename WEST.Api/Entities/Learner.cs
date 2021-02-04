using System.Collections.Generic;

namespace WEST.Api.Entities
{
    public class Learner
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public List<Course> Courses { get; set; }

    }
}