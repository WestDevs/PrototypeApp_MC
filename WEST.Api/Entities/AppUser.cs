using System;

namespace WEST.Api.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Birthdate { get; set; }
        public UserType Type { get; set; }
        public bool Status { get; set; }
        public int OrganisationId { get; set; }
        // to add relationship to Organisation

    }
}