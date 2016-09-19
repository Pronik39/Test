using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cars.Controllers
{
    public abstract class BaseController : Controller
    {
        public bool IsAuthenticated
        {
            get
            {
                return Request.Cookies[FormsAuthentication.FormsCookieName] != null && 
                FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value) != null;
            }
        }

    }
}
