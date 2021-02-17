using System.Threading.Tasks;
using WEST.Api.DTOs;
using WEST.Api.Entities;

namespace WEST.Api.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> CreateUser(RegisterDto registerDto);
        Task<LearnerDto> CreateLearner(RegisterLearnerDto registerLearnerDto);
    }
}