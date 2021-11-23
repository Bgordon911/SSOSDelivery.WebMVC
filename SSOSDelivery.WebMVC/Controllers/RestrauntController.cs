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
    public class RestrauntController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestrauntService(userId);
            var model = service.GetRestraunt();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestrauntCreate model)
        {
            if (!ModelState.IsValid) return View(model);
                 

                 var service = CreateRestrauntService();

                 if (service.CreateRestraunt(model))
                 {
                
                   TempData["SaveResult"]= "Your restraunt was created.";
                     return RedirectToAction("Index");
                 };

                ModelState.AddModelError("", "Restraunt could not be created");

            return View(model);
        }

        private RestrauntService CreateRestrauntService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestrauntService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRestrauntService();
            var model = svc.GetRestrauntById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateRestrauntService();
            var detail = service.GetRestrauntById(id);
            var model =
                new RestrauntEdit
                {
                    RestrauntId = detail.RestrauntId,
                    PhoneNumber = detail.Phonenumber,
                    Name = detail.Name
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, RestrauntEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RestrauntId != id)
            {
                ModelState.AddModelError("", "Id Match");
                return View(model);
            }

            var service = CreateRestrauntService();

            if (service.UpdateRestraunt(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your not could not be updated.");
            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRestrauntService();

            service.DeleteRestraunt(id);

            TempData["SaveResult"] = "Your restraunt was deleted";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var svc = CreateRestrauntService();
            var model = svc.GetRestrauntById(id);

            return View(model);

        }
    }
    
       

    
}