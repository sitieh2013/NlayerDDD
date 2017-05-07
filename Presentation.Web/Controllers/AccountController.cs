using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Application.Dependency.Common;
using Application.Security.Dtos;
using Application.Security.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Presentation.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ISecurityService _serviceSecurity;

        public AccountController()
        {
            _serviceSecurity = IocModule.GetSecurityService();
        }

        #region Login

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginDto model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            IdentityUser user;

            if (!_serviceSecurity.Login(model, out user)) return View(model);

            await SignInAsync(user, model.RememberMe);
            return RedirectToLocal(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region Helper

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private async Task SignInAsync(IdentityUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _serviceSecurity.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties {IsPersistent = isPersistent}, identity);
        }

        private void AddErrors(IEnumerable<string> errores)
        {
            ModelState.Clear();
            foreach (var t in errores)
                ModelState.AddModelError("Error", t);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}