using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;

namespace MvcAuthGoogle.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        public void ExternalLogin(string provider)
        {
            // just pass a provider to make it work
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("ExternalLoginCallback"));
        }
        public ActionResult ExternalLoginCallback()
        {
            var result = OAuthWebSecurity.VerifyAuthentication();

            if (result.IsSuccessful == false)
            {
                return RedirectToAction("Error", "Account");
            }

            // this is just demo. Make all things you need before setting cookies
            FormsAuthentication.SetAuthCookie(result.UserName, false);

            // We need to get the url user has entered to the browser to use it in the redirect. 
            // This is just demo.
            return Redirect(Url.Action("Index", "Secure"));
        }
    }
}