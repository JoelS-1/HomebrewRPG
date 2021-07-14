using HomebrewRPG.Models;
using HomebrewRPG.Models.CharacterSpell;
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
    public class CharacterSpellController : Controller
    {
        // GET: CharacterSpell
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New CharacterItem";

            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            var spellService = new SpellService(userId);

            List<CharacterListItem> characters = characterService.GetCharacters().ToList();
            var queryCharacter = from o in characters
                                 select new SelectListItem()
                                 {
                                     Value = o.CharacterId.ToString(),
                                     Text = o.CharacterName
                                 };
            ViewBag.CharacterId = queryCharacter.ToList();

            List<SpellListItem> spells = spellService.GetSpells().ToList();
            var queryItem = from o in spells
                            select new SelectListItem()
                            {
                                Value = o.SpellId.ToString(),
                                Text = o.SpellName
                            };
            ViewBag.SpellId = queryItem.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterSpellCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCharacterSpellService();
            if (service.CreateCharacterSpell(model))
            {
                TempData["SaveResult"] = "Your spell was added.";
                return RedirectToAction("CharacterSheet", "Character", new { id = model.CharacterId });
            };

            ModelState.AddModelError("", "Item could not be added.");

            return View("Index");
        }

        private CharacterSpellService CreateCharacterSpellService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterSpellService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCharacterSpellService();
            var model = svc.GetCharacterSpellById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateCharacterSpellService();
            var detail = svc.GetCharacterSpellById(id);
            var model =
                new CharacterSpellEdit
                {
                    CharacterSpellId = detail.CharacterSpellId,
                    CharacterId = detail.CharacterId,
                    SpellId = detail.SpellId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterSpellEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SpellId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCharacterSpellService();
            if (service.UpdateCharacterSpell(model))
            {
                TempData["SaveResult"] = "Updated.";
                return RedirectToAction("CharacterSheet", "Character", new { id = model.CharacterId });
            }
            ModelState.AddModelError("", "Your request could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCharacterSpellService();
            var model = svc.GetCharacterSpellById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateCharacterSpellService();
            svc.DeleteCharacterSpell(id);

            TempData["SaveResult"] = "Your spell was removed";

            return RedirectToAction("Index");
        }
    }
}