using HomebrewRPG.Models.CharacterWardrobeModels;
using HomebrewRPG.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomebrewRPG.WebMVC.Controllers
{
    public class CharacterWardrobeController : Controller
    {
        // GET: CharacterWardrobe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterWardrobeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCharacterWardrobeService();
            if (service.CreateCharacterWardrobe(model))
            {
                TempData["SaveResult"] = "Your apparel was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The apparel could not be added.");

            return View("Index");
        }

        private CharacterWardrobeService CreateCharacterWardrobeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterWardrobeService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateCharacterWardrobeService();
            var detail = svc.GetCharacterWardrobeById(id);
            var model =
                new CharacterWardrobeEdit
                {
                    CharacterWardrobeId = detail.CharacterWardrobeId,
                    CharacterId = detail.CharacterId,
                    WardrobeItemId = detail.WardrobeItemId,
                    IsEquipped = detail.IsEquipped
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterWardrobeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CharacterWardrobeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCharacterWardrobeService();
            if (service.UpdateCharacterWardrobe(model))
            {
                TempData["SaveResult"] = "Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your request could not be updated.");
            return View(model);
        }
    }
}