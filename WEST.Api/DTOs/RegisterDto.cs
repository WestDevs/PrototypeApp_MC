using System.ComponentModel.DataAnnotations;
using WEST.Api.Entities;

namespace WEST.Api.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int OrganisationId { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        public UserType Type { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}