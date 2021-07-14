using HomebrewRPG.Data;
using HomebrewRPG.Models;
using HomebrewRPG.Models.CharacterItemModels;
using HomebrewRPG.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomebrewRPG.WebMVC.Controllers
{
    public class CharacterItemController : Controller
    {
        // GET: CharacterItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New CharacterItem";

            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            var itemService = new ItemService(userId);

            List<CharacterListItem> characters = characterService.GetCharacters().ToList();
            var queryCharacter = from o in characters
                        select new SelectListItem()
                        {
                            Value = o.CharacterId.ToString(),
                            Text = o.CharacterName
                        };
            ViewBag.CharacterId = queryCharacter.ToList();

            List<ItemListItem> items = itemService.GetItems().ToList();
            var queryItem = from o in items
                        select new SelectListItem()
                        {
                            Value = o.ItemId.ToString(),
                            Text = o.ItemName
                        };
            ViewBag.ItemId = queryItem.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCharacterItemService();
            if (service.CreateCharacterItem(model))
            {
                TempData["SaveResult"] = "Your item was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Item could not be added.");

            return View("Index");
        }

        private CharacterItemService CreateCharacterItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterItemService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCharacterItemService();
            var model = svc.GetCharacterItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateCharacterItemService();
            var detail = svc.GetCharacterItemById(id);
            var model =
                new CharacterItemEdit
                {
                    CharacterItemId = detail.CharacterItemId,
                    CharacterId = detail.CharacterId,
                    ItemId = detail.ItemId,
                    Quantity = detail.Quantity
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCharacterItemService();
            if (service.UpdateCharacterItem(model))
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
            var svc = CreateCharacterItemService();
            var model = svc.GetCharacterItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateCharacterItemService();
            svc.DeleteCharacterItem(id);

            TempData["SaveResult"] = "Your item was deleted";

            return RedirectToAction("Index");
        }
    }
}