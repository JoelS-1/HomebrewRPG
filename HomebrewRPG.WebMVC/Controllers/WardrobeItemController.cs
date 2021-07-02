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
    }
}