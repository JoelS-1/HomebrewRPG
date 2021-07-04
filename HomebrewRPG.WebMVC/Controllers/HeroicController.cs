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

        public ActionResult Details(int id)
        {
            var svc = CreateHeroicService();
            var model = svc.GetByHeroicId(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateHeroicService();
            var detail = svc.GetByHeroicId(id);
            var model =
                new HeroicEdit
                {
                    HeroicId = detail.HeroicId,
                    HeroicName = detail.HeroicName,
                    IsPersonalHeroic = detail.IsPersonalHeroic,
                    Description = detail.Description,
                    RequiredLevel = detail.RequiredLevel,
                    RequiredHeroic = detail.RequiredHeroic,

                    RequiredAgility = detail.RequiredAgility,
                    RequiredStrength = detail.RequiredStrength,
                    RequiredInstinct = detail.RequiredInstinct,
                    RequiredIntelligence = detail.RequiredIntelligence,
                    RequiredCharisma = detail.RequiredCharisma,
                    RequiredHealth = detail.RequiredHealth
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HeroicEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HeroicId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateHeroicService();
            if (service.UpdateHeroic(model))
            {
                TempData["SaveResult"] = "Your heroic was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your heroic could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateHeroicService();
            var model = svc.GetByHeroicId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateHeroicService();
            svc.DeleteHeroic(id);

            TempData["SaveResult"] = "Your heroic was deleted";

            return RedirectToAction("Index");
        }
    }
}