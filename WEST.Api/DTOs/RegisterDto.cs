using System.ComponentModel.DataAnnotations;

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
        public int UserType { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}