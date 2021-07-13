using HomebrewRPG.Models;
using HomebrewRPG.Models.CharacterWeaponModels;
using HomebrewRPG.Models.WeaponModels;
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
            ViewBag.Title = "New CharacterWeapon";

            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            var weaponService = new WeaponService(userId);

            List<CharacterListItem> characters = characterService.GetCharacters().ToList();
            var queryCharacter = from o in characters
                                 select new SelectListItem()
                                 {
                                     Value = o.CharacterId.ToString(),
                                     Text = o.CharacterName
                                 };
            ViewBag.CharacterId = queryCharacter.ToList();

            List<WeaponListItem> weapons = weaponService.GetWeapons().ToList();
            var queryItem = from o in weapons
                            select new SelectListItem()
                            {
                                Value = o.WeaponId.ToString(),
                                Text = o.WeaponName
                            };
            ViewBag.ItemId = queryItem.ToList();
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
                    CharacterWeaponId = detail.CharacterWeaponId,
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

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCharacterWeaponService();
            var model = svc.GetCharacterWeaponById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateCharacterWeaponService();
            svc.DeleteCharacterWeapon(id);

            TempData["SaveResult"] = "Your characterWeapon was deleted";

            return RedirectToAction("Index");
        }
    }
}