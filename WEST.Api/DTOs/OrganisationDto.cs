using System.ComponentModel.DataAnnotations;

namespace WEST.Api.DTOs
{
    public class OrganisationDto
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}