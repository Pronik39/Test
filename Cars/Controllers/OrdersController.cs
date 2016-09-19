using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        //
        // GET: /Order/
        [HttpGet]
        public ActionResult Index(int id)
        {
            var orders = Settings.DataProvider.GetOrders(id);
            ViewBag.CarID = id;
            return View(orders);
        }

        [HttpPost]

        public ActionResult Create(int OrderAmount, int Status, int CarID)
        {
            var order = new Models.Order()
            {
                Date = DateTime.Now.ToShortDateString(),
                OrderAmount = OrderAmount,
                Status = (OrderStatus)Status,
                CarID = CarID
            };

            Settings.DataProvider.SaveOrder(order);
            var orders = Settings.DataProvider.GetOrders(CarID);
            ViewBag.CarID = CarID;
            return View("Index", orders);
        }

        public ActionResult Order(int id)
        {
            var order = Settings.DataProvider.GetOrder(id);
            return View(order);
        }

        public ActionResult Delete(int id)
        {
            var order = Settings.DataProvider.GetOrder(id);
            var carID = order.CarID;
            Settings.DataProvider.DeleteOrder(id);
            var orders = Settings.DataProvider.GetOrders(carID);
            ViewBag.CarID = carID;
            return View("Index", orders);
            
        }

        public ActionResult Save(Models.Order order)
        {
            Settings.DataProvider.SaveOrder(order);
            var orders = Settings.DataProvider.GetOrders(order.CarID);
            ViewBag.CarID = order.CarID;
            return View("Index", orders);

        }
    }


}
