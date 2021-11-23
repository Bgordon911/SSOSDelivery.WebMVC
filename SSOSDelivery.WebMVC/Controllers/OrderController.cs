
using Microsoft.AspNet.Identity;
using SOSDelivery.Service;
using SSOSDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSOSDelivery.WebMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           
            var service = CreateOrderService();
            var model = service.GetOrders();
            return View(model);
        }

        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            return service;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);





            var service = CreateOrderService();

            if (service.CreateOrder(model))
            {


                TempData["SaveResult"] = "Your order was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Order could not be created.");

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateOrderService();
            var detail = service.GetOrderById(id);
            var model =
                new OrderEdit
                {
                    ProductId = detail.ProductId
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEdit model)
        {
            if (!ModelState.IsValid) return View();

            if (model.OrderID != id)
            {
                ModelState.AddModelError("", "Id MisMatch");
                return View(model);
            }

            var service = CreateOrderService();

            if (service.UpdateOrder(model))
            {
                TempData["SaveResult"] = "You order was updated";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Your order could not be updated");
            return View(model);



        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOrderService();

            service.DeleteOrder(id);

            TempData["SaveResult"] = "Your order was deleted";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);

        }
    }
}