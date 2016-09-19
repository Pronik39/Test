using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cars.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        [HttpPost]
        public ActionResult Login(string password)
        {
            if (Settings.DataProvider.PasswordValid(password))
            { 
                FormsAuthentication.SetAuthCookie(string.Empty, false);
                return RedirectToAction("Index", "Home");
            }

            return View("Index",true);
            
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(false);
        }

    }
}
