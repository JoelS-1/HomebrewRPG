﻿using HomebrewRPG.Models;
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
            var model = new CharacterListItem[0];
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
            if(ModelState.IsValid)
            {

            }
            return View();
        }
    }
}