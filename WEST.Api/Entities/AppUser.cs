using System;

namespace WEST.Api.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public UserType Type { get; set; }
        public bool Status { get; set; }

    }
}