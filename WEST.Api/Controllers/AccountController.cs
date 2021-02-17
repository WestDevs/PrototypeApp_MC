using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEST.Api.Data;
using WEST.Api.DTOs;
using WEST.Api.Entities;
using WEST.Api.Interfaces;

namespace WEST.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AccountController(DataContext context,
                                 ITokenService tokenService,
                                 IUserService userService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            
            var user = await _userService.CreateUser(registerDto);

            if (user == null) return BadRequest("Username is taken");

            if (user.Type == (await _context.UserTypes.AsQueryable().SingleAsync(ut => ut.Name == "Learner")))
                await _userService.CreateLearner(new RegisterLearnerDto {
                    UserId = user.Id,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Username = user.Username,
                    Password = registerDto.Password
                });
   
            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync<AppUser>(user => user.Username == loginDto.Username && user.Organisation.Id == loginDto.OrganisationId);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }


            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };

        }



    }
}