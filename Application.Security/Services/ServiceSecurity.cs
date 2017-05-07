using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Security.Dtos;
using Data.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Application.Security.Services
{
    public class ServiceSecurity : ISecurityService
    {
        private UserManager<IdentityUser> UserManagerAdapter { get; set; }

        public ServiceSecurity()
        {
            UserManagerAdapter = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new DataBaseContext()));
        }

        public bool Login(LoginDto model, out IdentityUser user, out List<string> exceptions)
        {
            exceptions = new List<string>();
            user = UserManagerAdapter.Find(model.UserName, model.Password);

            if (user != null)
            {
                if (!user.LockoutEnabled) return true;

                exceptions.Add("Este usuario está deshabilitado.");
                return false;
            }

            exceptions.Add("Verificar el nombre usuario o contraseña.");
            return false;
        }

        public bool Login(LoginDto model, out IdentityUser user)
        {
            model.Errores = new List<string>();
            user = UserManagerAdapter.Find(model.UserName, model.Password);

            if (user != null)
            {
                if (!user.LockoutEnabled) return true;

                model.Errores.Add("Este usuario está deshabilitado.");
                return false;
            }

            model.Errores.Add("Verificar el nombre usuario o contraseña.");
            return false;
        }

        public bool Register(RegisterDto model, out List<string> exceptions)
        {
            exceptions = new List<string>();
            var user = new IdentityUser(model.UserName);
            var result = UserManagerAdapter.Create(user, model.Password);
            if (result.Succeeded)
                UserManagerAdapter.AddToRoleAsync(user.Id, model.Rol);
            else
            {
                exceptions.AddRange(result.Errors.Select(item => item));
                return false;
            }

            return true;
        }

        public bool SetUser(UsersDto user, out List<string> exceptions)
        {
            exceptions = new List<string>();
            var usertemp = UserManagerAdapter.FindByName(user.UserName);

            usertemp.UserName = user.UserNameNew;
            usertemp.LockoutEnabled = user.Enabled;
            var result = UserManagerAdapter.Update(usertemp);

            if (result.Succeeded)
            {
                UserManagerAdapter.AddToRole(usertemp.UserName, user.RolNew);
                UserManagerAdapter.RemoveFromRole(usertemp.UserName, user.Rol);

                return true;
            }

            exceptions.AddRange(result.Errors.Select(item => item));
            return false;
        }

        public bool SetUserPassword(UsersDto user, out List<string> exceptions)
        {
            exceptions = new List<string>();
            var result = UserManagerAdapter.RemovePassword(user.UserName);

            if (result.Succeeded)
            {
                var changed = UserManagerAdapter.AddPassword(user.UserName, user.PasswordNew);

                if (changed.Succeeded)
                    return true;
            }

            exceptions.AddRange(result.Errors.Select(item => item));
            return false;
        }

        public Task<ClaimsIdentity> CreateIdentity(IdentityUser user, string applicationCookie)
        {
            return UserManagerAdapter.CreateIdentityAsync(user, applicationCookie);
        }
    }
}