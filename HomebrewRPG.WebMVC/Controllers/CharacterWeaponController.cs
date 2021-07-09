using HomebrewRPG.Models.CharacterWeaponModels;
using HomebrewRPG.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomebrewRPG.WebMVC.Controllers
{
    public class CharacterWeaponController : Controller
    {
        // GET: CharacterWeapon
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
        public ActionResult Create(CharacterWeaponCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCharacterWeaponService();
            if (service.CreateCharacterWeapon(model))
            {
                TempData["SaveResult"] = "Your weapon was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The weapon could not be added.");

            return View("Index");
        }

        private CharacterWeaponService CreateCharacterWeaponService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterWeaponService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateCharacterWeaponService();
            var detail = svc.GetCharacterWeaponById(id);
            var model =
                new CharacterWeaponEdit
                {
                    CharacterId = detail.CharacterId,
                    WeaponId = detail.WeaponId,
                    IsEquipped = detail.IsEquipped
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterWeaponEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WeaponId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCharacterWeaponService();
            if (service.UpdateCharacterWeapon(model))
            {
                TempData["SaveResult"] = "Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your request could not be updated.");
            return View(model);
        }
    }
}