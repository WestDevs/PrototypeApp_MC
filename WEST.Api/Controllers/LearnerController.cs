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

            var learnerUsers = await _context.Users
                                .AsQueryable()
                                .Where(user => user.Type == _context.UserTypes.Find(3)) // server-evaluated
                                .ToListAsync();

            foreach (var learnerUser in learnerUsers)
            {
                // select the user from learners table
                var learners = await _context.Learners
                                .AsQueryable()
                                .Where(learner => learner.User == learnerUser)
                                .ToListAsync();

                if (learners == null) return null;

                foreach (var learner in learners)
                {
                    string groupName = null;
                    if (await _context.LearnerGroup.AnyAsync(lg => lg.LearnerId == learner.LearnerId))
                        groupName = (await _context.Groups.FindAsync(
                            (await _context.LearnerGroup.AsQueryable().SingleAsync
                            (lg => lg.LearnerId == learner.LearnerId)).GroupId)).Name;

                    learnersDto.Add(new LearnerDto
                    {
                        UserId = learnerUser.Id,
                        LearnerId = learner.LearnerId,
                        Username = learnerUser.Username,
                        // GroupName = (await _context.LearnerGroup.AsQueryable().SingleAsync(lg => lg.LearnerId == learner.LearnerId)).Group.Name,
                        GroupName = groupName,
                        Firstname = learnerUser.Firstname,
                        Lastname = learnerUser.Lastname
                    });
                }
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