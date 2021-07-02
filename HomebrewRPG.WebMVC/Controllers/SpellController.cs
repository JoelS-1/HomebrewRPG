using HomebrewRPG.Models.SpellModels;
using HomebrewRPG.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomebrewRPG.WebMVC.Controllers
{
    public class SpellController : Controller
    {
        // GET: Spell
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpellService(userId);
            var model = service.GetSpells();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSpellService();
            if (service.CreateSpell(model))
            {
                TempData["SaveResult"] = "Your spell was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your spell could not be created.");

            return View("Index");
        }

        private SpellService CreateSpellService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpellService(userId);
            return service;
        }
    }
}