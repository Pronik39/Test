using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        //
        // GET: /Clinet/
        [HttpGet]
        public ActionResult Index(string email)
        {
            var client = Settings.DataProvider.GetClient(email);
            return View(client);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Index", new Models.Client());
        }

        [HttpPost]
        public ActionResult Save(Models.Client client)
        {
            Settings.DataProvider.SaveClient(client);
            return View("Index", client);

        }

        public ActionResult CreateCar(Models.Car car)
        {
            var clientId = int.Parse(Request.Params["ClientID"]);
            Settings.DataProvider.SaveCar(car, clientId);
            var client = Settings.DataProvider.GetClient(clientId);
            return View("Index", client);

        }

        public ActionResult DeleteCar(int carID, int clientID)
        {
            Settings.DataProvider.DeleteCar(carID);
            var client = Settings.DataProvider.GetClient(clientID);
            return View("Index", client);

        }

      
    }
}
