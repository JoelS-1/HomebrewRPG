using HomebrewRPG.Models.WalletModels;
using HomebrewRPG.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomebrewRPG.WebMVC.Controllers
{
    public class WalletController : Controller
    {
        // GET: Wallet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WalletService(userId);
            var model = service.GetWallets();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WalletCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWalletService();
            if (service.CreateWallet(model))
            {
                TempData["SaveResult"] = "Your wallet was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Wallet could not be created.");

            return View("Index");
        }

        private WalletService CreateWalletService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WalletService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateWalletService();
            var model = svc.GetWalletById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateWalletService();
            var detail = svc.GetWalletById(id);
            var model =
                new WalletEdit
                {
                    WalletId = detail.WalletId,
                    CharacterId = detail.CharacterId,
                    Gold = detail.Gold,
                    Silver = detail.Silver,
                    Copper = detail.Copper
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WalletEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WalletId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateWalletService();
            if (service.UpdateWallet(model))
            {
                TempData["SaveResult"] = "Your wallet was updated.";
                return RedirectToAction("CharacterSheet", "Character", new { id = model.CharacterId });
            }
            ModelState.AddModelError("", "Your wallet could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWalletService();
            var model = svc.GetWalletById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateWalletService();
            svc.DeleteWallet(id);

            TempData["SaveResult"] = "Your wallet was deleted";

            return RedirectToAction("Index");
        }
    }
}