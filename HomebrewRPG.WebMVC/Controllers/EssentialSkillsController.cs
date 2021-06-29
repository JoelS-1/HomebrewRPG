using HomebrewRPG.Models.EssentialSkillsModels;
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
    public class EssentialSkillsController : Controller
    {
        // GET: EssentialSkills
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EssentialSkillsService(userId);
            var model = service.GetSkills();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EssentialSkillsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEssentialSkillsService();
            if (service.CreateEssentialSkills(model))
            {
                TempData["SaveResult"] = "Your character was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Character could not be created.");

            return View("Index");
        }

        private EssentialSkillsService CreateEssentialSkillsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EssentialSkillsService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEssentialSkillsService();
            var model = svc.GetSkillsById(id);

            return View(model);
        }
    }
}