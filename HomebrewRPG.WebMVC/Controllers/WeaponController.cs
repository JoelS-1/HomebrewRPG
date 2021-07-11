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
            ViewBag.Title = "New Weapon";

            List<string> weaponTypes = new List<string>()
            {
                "strength",
                "agility",
                "magic"
            };
            var query = from o in weaponTypes
                             select new SelectListItem()
                             {
                                 Value = o,
                                 Text = o
                             };
            ViewBag.WeaponType = query.ToList();

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

        public ActionResult Details(int id)
        {
            var svc = CreateWeaponService();
            var model = svc.GetWeaponById(id);

            return View(model);
        }

        private WeaponService CreateWeaponService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeaponService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Weapon";

            List<string> weaponTypes = new List<string>()
            {
                "strength",
                "agility",
                "magic"
            };
            var query = from o in weaponTypes
                             select new SelectListItem()
                             {
                                 Value = o,
                                 Text = o
                             };
            ViewBag.WeaponType = query.ToList();

            var svc = CreateWeaponService();
            var detail = svc.GetWeaponById(id);
            var model =
                new WeaponEdit
                {
                    WeaponId = detail.WeaponId,
                    WeaponName = detail.WeaponName,
                    Description = detail.Description,
                    WeaponType = detail.WeaponType,
                    DamageDice = detail.DamageDice,
                    DamageModifier = detail.DamageModifier,
                    Range = detail.Range,
                    CriticalRange = detail.CriticalRange,
                    Special = detail.Special,
                    Parrying = detail.Parrying,
                    PhysicalBlocking = detail.PhysicalBlocking,
                    MagicalBlocking = detail.MagicalBlocking,

                    Health = detail.Health,
                    Strength = detail.Strength,
                    Instinct = detail.Instinct,
                    Agility = detail.Agility,
                    Intelligence = detail.Intelligence,
                    Charisma = detail.Charisma,

                    HitPoints = detail.HitPoints,
                    Sanity = detail.Sanity,
                    Dodge = detail.Dodge,
                    Reaction = detail.Reaction,
                    ProwessBonus = detail.ProwessBonus,
                    Magic = detail.Magic,
                    Fate = detail.Fate,
                    Speed = detail.Speed,


                    Endurance = detail.Endurance,
                    Constitution = detail.Constitution,
                    Athletics = detail.Athletics,
                    Tenacity = detail.Tenacity,
                    Acrobatics = detail.Acrobatics,
                    SleightOfHand = detail.SleightOfHand,
                    Sneak = detail.Sneak,
                    Willpower = detail.Willpower,
                    Investigation = detail.Investigation,
                    Knowledge = detail.Knowledge,
                    Bravery = detail.Bravery,
                    Pilotry = detail.Pilotry,
                    Insight = detail.Insight,
                    Perception = detail.Perception,
                    Survival = detail.Survival,
                    Faith = detail.Faith,
                    Deception = detail.Deception,
                    Diplomacy = detail.Diplomacy,
                    Intimidation = detail.Intimidation,
                    Performance = detail.Performance,
                    Seduction = detail.Seduction,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WeaponEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WeaponId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateWeaponService();
            if (service.UpdateWeapon(model))
            {
                TempData["SaveResult"] = "Your Weapon was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Weapon could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWeaponService();
            var model = svc.GetWeaponById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateWeaponService();
            svc.DeleteWeapon(id);

            TempData["SaveResult"] = "Your Weapon was deleted";

            return RedirectToAction("Index");
        }
    }
}