using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Security.Dtos;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Application.Security.Services
{
    public interface ISecurityService
    {
        bool Login(LoginDto model, out IdentityUser user, out List<string> exceptions);

        bool Login(LoginDto model, out IdentityUser user);

        bool Register(RegisterDto model, out List<string> exceptions);

        bool SetUser(UsersDto user, out List<string> exceptions);

        bool SetUserPassword(UsersDto user, out List<string> exceptions);

        Task<ClaimsIdentity> CreateIdentity(IdentityUser user, string applicationCookie);
    }
}
