using WEST.Api.Entities;

namespace WEST.Api.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
         
    }
}