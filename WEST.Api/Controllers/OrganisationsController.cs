using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEST.Api.Data;
using WEST.Api.DTOs;
using WEST.Api.Entities;

namespace WEST.Api.Controllers
{
    public class OrganisationsController : BaseApiController
    {
        private readonly DataContext _context;
        public OrganisationsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Organisation>>> GetOrganisations()
        {
            return await _context.Organisations.ToListAsync();
        }    

        [HttpPost("register")]
        public async Task<ActionResult<OrganisationDto>> Register(OrganisationDto organisationDto)
        {
            var organisation = new Organisation
            {
                Name = organisationDto.Name
            };

            _context.Organisations.Add(organisation);
            await _context.SaveChangesAsync();

            return new OrganisationDto
            {
                Id = organisation.Id,
                Name = organisation.Name
            };
        }

        
    }
    
}