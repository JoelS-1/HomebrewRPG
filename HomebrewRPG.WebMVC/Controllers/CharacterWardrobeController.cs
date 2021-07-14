using HomebrewRPG.Models;
using HomebrewRPG.Models.CharacterWardrobeModels;
using HomebrewRPG.Models.WardrobeItemModels;
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
            ViewBag.Title = "New CharacterWardrobe";

            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            var wardrobeItemService = new WardrobeItemService(userId);

            List<CharacterListItem> characters = characterService.GetCharacters().ToList();
            var queryCharacter = from o in characters
                                 select new SelectListItem()
                                 {
                                     Value = o.CharacterId.ToString(),
                                     Text = o.CharacterName
                                 };
            ViewBag.CharacterId = queryCharacter.ToList();

            List<WardrobeListItem> apparel = wardrobeItemService.GetWardrobeListItems().ToList();
            var queryItem = from o in apparel
                            select new SelectListItem()
                            {
                                Value = o.WardobeItemId.ToString(),
                                Text = o.ArmorName
                            };
            ViewBag.WardrobeItemId = queryItem.ToList();
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

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCharacterWardrobeService();
            var model = svc.GetCharacterWardrobeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateCharacterWardrobeService();
            svc.DeleteCharacterWardrobe(id);

            TempData["SaveResult"] = "Your apparel was removed";

            return RedirectToAction("Index");
        }
    }
}