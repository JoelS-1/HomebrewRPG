using HomebrewRPG.Models.HeroicModels;
using HomebrewRPG.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomebrewRPG.WebMVC.Controllers
{
    public class HeroicController : Controller
    {
        // GET: Heroic
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HeroicService(userId);
            var model = service.GetHeroics();
            return View(model);
        }

        private HeroicService CreateHeroicService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HeroicService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HeroicCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHeroicService();
            if (service.CreateHeroic(model))
            {
                TempData["SaveResult"] = "Your heroic was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your heroic could not be created.");

            return View("Index");
        }
    }
}