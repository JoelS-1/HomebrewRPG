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
    [Authorize]
    public class WeaponController : Controller
    {
        // GET: Weapon
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeaponService(userId);
            var model = service.GetWeapons();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeaponCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWeaponService();
            if (service.CreateWeapon(model))
            {
                TempData["SaveResult"] = "Your character was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Character could not be created.");

            return View("Index");
        }

        private WeaponService CreateWeaponService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeaponService(userId);
            return service;
        }
    }
}