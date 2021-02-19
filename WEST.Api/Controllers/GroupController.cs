using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEST.Api.Data;
using WEST.Api.DTOs;
using WEST.Api.Entities;

namespace WEST.Api.Controllers
{
    public class GroupController : BaseApiController
    {
        private readonly DataContext _dataContext;
        public GroupController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups() 
        {
            var groups = await _dataContext.Groups.ToListAsync();
            List<GroupDto> groupDtos = new List<GroupDto>();

            foreach (var group in groups)
                groupDtos.Add(new GroupDto {
                                    Id = group.Id,
                                    Name = group.Name
                                    });
             return groupDtos;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Group>> RegisterGroup(GroupDto newGroup) 
        {
            var group = new Group {
                Id = newGroup.Id,
                Name = newGroup.Name
            };

            _dataContext.Groups.Add(group);
            await _dataContext.SaveChangesAsync();

            return group;
        }
    }
}