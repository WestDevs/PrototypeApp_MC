using System.Collections.Generic;
using WEST.Api.Entities;

namespace WEST.Api.DTOs
{
    public class RegisterLearnerDto : LearnerDto
    {
        public string Password { get; set; }

    }
}