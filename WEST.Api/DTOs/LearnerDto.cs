using System.Collections.Generic;
using WEST.Api.Entities;

namespace WEST.Api.DTOs
{
    public class LearnerDto 
    {
        public int UserId { get; set; }
        public int LearnerId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string GroupName { get; set; }
        public int OrganisationId { get; set; }
        public ICollection<int> Courses { get; set; }
        public LearnerDto()
        {
            this.Courses = new HashSet<int>();
        }
    }
}