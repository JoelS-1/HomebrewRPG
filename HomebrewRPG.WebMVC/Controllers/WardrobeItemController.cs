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
    public class WardrobeItemController : Controller
    {
        // GET: WardrobeItem
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WardrobeItemService(userId);
            var model = service.GetWardrobeListItems();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Wardrobe Item";

            List<string> armorTypes = new List<string>()
            {
                "head",
                "chest",
                "legs",
                "gloves",
                "ring",
                "amulet",
                "cloak",
                "feet",
                "misc"
            };
            var query = from o in armorTypes
                        select new SelectListItem()
                        {
                            Value = o,
                            Text = o
                        };
            ViewBag.ArmorType = query.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WardrobeItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWardrobeItemService();
            if (service.CreateWardrobeItem(model))
            {
                TempData["SaveResult"] = "Your wardrobe item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Wardrobe item could not be created.");

            return View("Index");
        }

        private WardrobeItemService CreateWardrobeItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WardrobeItemService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateWardrobeItemService();
            var model = svc.GetWardrobeItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Wardrobe Item";

            List<string> armorTypes = new List<string>()
            {
                "head",
                "chest",
                "legs",
                "gloves",
                "ring",
                "amulet",
                "cloak",
                "feet",
                "misc"
            };
            var query = from o in armorTypes
                        select new SelectListItem()
                        {
                            Value = o,
                            Text = o
                        };
            ViewBag.ArmorType = query.ToList();

            var svc = CreateWardrobeItemService();
            var detail = svc.GetWardrobeItemById(id);
            var model =
                new WardrobeItemEdit
                {
                    WardobeItemId = detail.WardobeItemId,
                    ArmorName = detail.ArmorName,
                    ArmorType = detail.ArmorType,
                    Description = detail.Description,
                    HealthRequired = detail.HealthRequired,
                    StrengthRequired = detail.StrengthRequired,
                    AgilityRequired = detail.AgilityRequired,
                    MagicRequired = detail.MagicRequired,
                    Special = detail.Special,
                    PhysicalBlocking = detail.PhysicalBlocking,
                    MagicalBlocking = detail.MagicalBlocking,
                    PhysicalResistance = detail.PhysicalResistance,
                    MagicalResistance = detail.MagicalResistance
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WardrobeItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WardobeItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateWardrobeItemService();
            if (service.UpdateWardrobeItem(model))
            {
                TempData["SaveResult"] = "Your wardrobe item was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your wardrobe item could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWardrobeItemService();
            var model = svc.GetWardrobeItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateWardrobeItemService();
            svc.DeleteWardrobeItem(id);

            TempData["SaveResult"] = "Your wardrobe item was deleted";

            return RedirectToAction("Index");
        }
    }
}