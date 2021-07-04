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

        public ActionResult Details(int id)
        {
            var svc = CreateSpellService();
            var model = svc.GetSpellById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateSpellService();
            var detail = svc.GetSpellById(id);
            var model =
                new SpellEdit
                {
                    SpellId = detail.SpellId,
                    SpellName = detail.SpellName,
                    SpellDescription = detail.SpellDescription,
                    SpellEffect = detail.SpellEffect,
                    SpellType = detail.SpellType,
                    Range = detail.Range,
                    SpellDC = detail.SpellDC
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpellEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SpellId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSpellService();
            if (service.UpdateSpell(model))
            {
                TempData["SaveResult"] = "Your spell was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your spell could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSpellService();
            var model = svc.GetSpellById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateSpellService();
            svc.DeleteSpell(id);

            TempData["SaveResult"] = "Your spell was deleted";

            return RedirectToAction("Index");
        }
    }
}