using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEST.Api.Data;
using WEST.Api.DTOs;
using WEST.Api.Entities;
using WEST.Api.Interfaces;

namespace WEST.Api.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private const string defaultPassword = "password";
        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<AppUser> CreateUser(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return null;

            using var hmac = new HMACSHA512(); //will provide hashing algorithm
            var user = new AppUser
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Organisation = await _dataContext.Organisations.FindAsync(registerDto.OrganisationId),
                Type = await _dataContext.UserTypes.FindAsync(registerDto.UserTypeId),
                Firstname = registerDto.Firstname,
                Lastname = registerDto.Lastname
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            
            return user;

        }

        private AppUser BadRequest(string v)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LearnerDto> CreateLearner(RegisterLearnerDto registerLearnerDto)
        {
            AppUser user = new AppUser();

            if (registerLearnerDto.UserId == 0) // no user yet 
            {
                var orgId = registerLearnerDto.OrganisationId == 0 ?
                                registerLearnerDto.Organisation.Id :
                                registerLearnerDto.OrganisationId;
                if (orgId == 0) return null;

                user = await CreateUser(new RegisterDto {
                    Username = registerLearnerDto.Username,
                    Password = registerLearnerDto.Password,
                    OrganisationId = orgId,
                    UserTypeId = (await _dataContext.UserTypes.AsQueryable().SingleAsync(ut => ut.Name == "Learner")).Id,
                    Firstname = registerLearnerDto.Firstname,
                    Lastname = registerLearnerDto.Lastname
                });
            }

            if ( user == null && registerLearnerDto.UserId == 0) return null;
            var learner = new Learner
                {
                    UserId = user.Id == 0 ? registerLearnerDto.UserId : user.Id
                };

            _dataContext.Learners.Add(learner);
            await _dataContext.SaveChangesAsync();

            LearnerGroup learnerGroup = new LearnerGroup();
            if (registerLearnerDto.Group != null)
            {
                learnerGroup.LearnerId = learner.LearnerId;
                learnerGroup.GroupId = registerLearnerDto.Group.Id;
                _dataContext.LearnerGroup.Add(learnerGroup);
                await _dataContext.SaveChangesAsync();
            }

            if (registerLearnerDto.Courses != null && registerLearnerDto.Courses.Count > 0)
            {
                foreach (var course in registerLearnerDto.Courses)
                    _dataContext.LearnerCourses.Add(new LearnerCourse {
                        LearnerId = learner.LearnerId,
                        CourseId = course.Id
                        // CourseId = course
                    });
                await _dataContext.SaveChangesAsync();
            }
            return new LearnerDto {
                UserId = registerLearnerDto.UserId,
                LearnerId = learner.LearnerId,
                OrganisationId = user.OrganisationId,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Group = learnerGroup.Group == null ? null : new GroupDto {
                        Id = learnerGroup.Group.Id,
                        Name = learnerGroup.Group.Name },
                Courses = registerLearnerDto.Courses
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _dataContext.Users.AnyAsync(u => u.Username == username.ToLower());

        }

    }
}