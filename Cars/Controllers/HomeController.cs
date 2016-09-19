using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cars.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            if (IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
