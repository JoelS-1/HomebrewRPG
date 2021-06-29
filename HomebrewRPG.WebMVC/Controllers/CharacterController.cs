using HomebrewRPG.Models;
using HomebrewRPG.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomebrewRPG.WebMVC.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            var model = service.GetCharacters();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateCharacterService();
            if (service.CreateCharacter(model))
            {
                TempData["SaveResult"] = "Your character was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Character could not be created.");

            return View("Index");
        }

        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            return service;
        }
    }
}