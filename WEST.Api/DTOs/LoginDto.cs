namespace WEST.Api.DTOs
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int OrganisationId { get; set; }
    }
}