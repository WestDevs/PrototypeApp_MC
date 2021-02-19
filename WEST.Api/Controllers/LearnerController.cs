using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEST.Api.Data;
using WEST.Api.DTOs;
using WEST.Api.Entities;
using WEST.Api.Interfaces;

namespace WEST.Api.Controllers
{
    public class LearnerController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;
        public LearnerController(DataContext context,
                                 IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<LearnerDto>>> GetLearners()
        {
            List<LearnerDto> learnersDto = new List<LearnerDto>();
            var learners = await _context.Learners
                                .Include(l => l.LearnerGroup.Group)
                                .Include(l => l.LearnerCourses)
                                .Include(l => l.User)
                                .Include(l => l.User.Type)
                                .Include(l => l.User.Organisation)
                                .ToListAsync();
            // if (learners == null) return null;


            foreach (var learner in learners)
            {
                var learnerDto = new LearnerDto
                {
                    UserId = learner.User.Id,
                    LearnerId = learner.LearnerId,
                    Username = learner.User.Username,
                    Group = learner.LearnerGroup == null ? null :  
                                new GroupDto {
                                    Id = learner.LearnerGroup.Group.Id,
                                    Name = learner.LearnerGroup.Group.Name },
                    Firstname = learner.User.Firstname,
                    Lastname = learner.User.Lastname,
                    Organisation = learner.User.Organisation
                };

                foreach (var learnerCourse in learner.LearnerCourses)
                {
                    var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == learnerCourse.CourseId);
                    learnerDto.Courses.Add(new CourseDto { 
                                                Id = course.Id,
                                                Name = course.Name,
                                                IconPath = course.IconPath
                    });
                }

                learnersDto.Add(learnerDto);

            }
            return learnersDto;

        }

        [HttpPost("register")]
        public async Task<ActionResult<LearnerDto>> RegisterLearner(RegisterLearnerDto registerLearnerDto)
        {
            var learner =  await _userService.CreateLearner(registerLearnerDto);
            if (learner == null) return BadRequest("An error was encountered when creating the learner.");
            return learner;

        }
        // // api/learners/3
        // [Authorize]
        // [HttpGet("{id}")]
        // public async Task<ActionResult<LearnerDto>> GetUser(int id)
        // {
        //     return await _context.Users.FindAsync(id);
        // }
        // public async Task<ActionResult<LearnerDto>> Register(LearnerDto learnerDto)
        // {
        //     // 1. If user exists, bad request
        //     // 2. if user doesnt exists
        //     if (await UserExists(registerDto.Username))


        //         return BadRequest("Username is taken");
        //     using var hmac = new HMACSHA512(); //will provide hashing algorithm

        //     var user = new AppUser
        //     {
        //         Username = registerDto.Username.ToLower(),
        //         PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //         PasswordSalt = hmac.Key
        //     };

        //     _context.Users.Add(user);
        //     await _context.SaveChangesAsync();

        //     return new UserDto
        //     {
        //         Username = user.Username,
        //         Token = _tokenService.CreateToken(user)
        //     };
        // }
    }
}