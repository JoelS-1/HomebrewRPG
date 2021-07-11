﻿using HomebrewRPG.Data;
using HomebrewRPG.Models;
using HomebrewRPG.Models.CharacterItemModels;
using HomebrewRPG.Models.CharacterWardrobeModels;
using HomebrewRPG.Models.CharacterWeaponModels;
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
            ViewBag.Title = "New Character";

            List<string> magicTypes = new List<string>()
            {
                "charisma",
                "intelligence",
                "instinct"
            };
            var magicQuery = from o in magicTypes
                             select new SelectListItem()
                             {
                                 Value = o,
                                 Text = o
                             };
            ViewBag.MagicType = magicQuery.ToList();

            List<string> prowessTypes = new List<string>()
            {
                "agility",
                "strength"
            };
            var prowessQuery = from o in prowessTypes
                               select new SelectListItem()
                               {
                                   Value = o,
                                   Text = o
                               };
            ViewBag.ProwessType = prowessQuery.ToList();

            var model =
                new CharacterCreate
                {
                    CharacterLevel = 1,
                    Health = 0,
                    Strength = 0,
                    Instinct = 0,
                    Agility = 0,
                    Intelligence = 0,
                    Charisma = 0,

                    Endurance = 0,
                    Constitution = 0,
                    Athletics = 0,
                    Tenacity = 0,
                    Acrobatics = 0,
                    SleightOfHand = 0,
                    Sneak = 0,
                    Willpower = 0,
                    Investigation = 0,
                    Knowledge = 0,
                    Bravery = 0,
                    Pilotry = 0,
                    Insight = 0,
                    Perception = 0,
                    Survival = 0,
                    Faith = 0,
                    Deception = 0,
                    Diplomacy = 0,
                    Intimidation = 0,
                    Performance = 0,
                    Seduction = 0,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

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

        public ActionResult Details(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }

        public ActionResult CharacterSheet(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            var characterItemService = new CharacterItemService(userId);
            var characterWeaponService = new CharacterWeaponService(userId);
            var characterWardrobeItemService = new CharacterWardrobeService(userId);


            CharacterSheetModel model = new CharacterSheetModel();
            model.CharacterDetail = characterService.GetCharacterById(id);
            //model.items = characterItemService.GetCharacterItemsByCharacterId(id);

            var itemList = characterItemService.GetCharacterItemsByCharacterId(id);
            foreach (var x in itemList)
            {
                CharacterItemDetail y = new CharacterItemDetail();
                {

                    y.CharacterId = x.CharacterId;
                    y.ItemId = x.ItemId;
                    y.Quantity = x.Quantity;
                    y.ItemName = x.ItemName;
                    y.ItemDescription = x.ItemDescription;
                };
                model.Items.Add(y);
            }
            var weaponList = characterWeaponService.GetCharacterWeaponsByCharacterId(id);
            foreach (var x in weaponList)
            {
                CharacterWeaponDetail y = new CharacterWeaponDetail();
                {

                    y.CharacterId = x.CharacterId;
                    y.CharacterWeaponId = x.CharacterWeaponId;
                    y.WeaponId = x.WeaponId;
                    y.IsEquipped = x.IsEquipped;

                    y.WeaponName = x.WeaponName;
                    y.Description = x.Description;
                    y.WeaponType = x.WeaponType;
                    y.DamageDice = x.DamageDice;
                    y.DamageModifier = x.DamageModifier;
                    y.ProwessBonus = x.ProwessBonus;
                    y.Range = x.Range;
                    y.CriticalRange = x.CriticalRange;
                    y.Special = x.Special;

                    if (x.IsEquipped)
                    {
                        model.CharacterDetail.Health += x.Health;
                        model.CharacterDetail.Strength += x.Strength;
                        model.CharacterDetail.Instinct += x.Instinct;
                        model.CharacterDetail.Agility += x.Agility;
                        model.CharacterDetail.Intelligence += x.Intelligence;
                        model.CharacterDetail.Charisma += x.Charisma;

                        model.CharacterDetail.HitPoints += x.HitPoints;
                        model.CharacterDetail.Sanity += x.Sanity;
                        model.CharacterDetail.Dodge += x.Dodge;
                        model.CharacterDetail.Reaction += x.Reaction;
                        model.CharacterDetail.Magic += x.Magic;
                        model.CharacterDetail.BaseProwess += x.ProwessBonus;
                        model.CharacterDetail.Fate += x.Fate;

                        model.CharacterDetail.Endurance += x.Endurance;
                        model.CharacterDetail.Constitution += x.Constitution;
                        model.CharacterDetail.Athletics += x.Athletics;
                        model.CharacterDetail.Tenacity += x.Tenacity;
                        model.CharacterDetail.Acrobatics += x.Acrobatics;
                        model.CharacterDetail.SleightOfHand += x.SleightOfHand;
                        model.CharacterDetail.Sneak += x.Sneak;
                        model.CharacterDetail.Willpower += x.Willpower;
                        model.CharacterDetail.Investigation += x.Investigation;
                        model.CharacterDetail.Knowledge += x.Knowledge;
                        model.CharacterDetail.Bravery += x.Bravery;
                        model.CharacterDetail.Pilotry += x.Pilotry;
                        model.CharacterDetail.Insight += x.Insight;
                        model.CharacterDetail.Perception += x.Perception;
                        model.CharacterDetail.Survival += x.Survival;
                        model.CharacterDetail.Faith += x.Faith;
                        model.CharacterDetail.Deception += x.Deception;
                        model.CharacterDetail.Diplomacy += x.Diplomacy;
                        model.CharacterDetail.Intimidation += x.Intimidation;
                        model.CharacterDetail.Performance += x.Performance;
                        model.CharacterDetail.Seduction += x.Seduction;
                    }
                };
                model.Weapons.Add(y);
            }
            var wardrobeList = characterWardrobeItemService.GetCharacterWardrobeListByCharacterId(id);
            foreach (var x in wardrobeList)
            {
                CharacterWardrobeDetail y = new CharacterWardrobeDetail();
                {

                    y.CharacterId = x.CharacterId;
                    y.CharacterWardrobeId = x.CharacterWardrobeId;
                    y.WardrobeItemId = x.WardrobeItemId;
                    y.IsEquipped = x.IsEquipped;

                    y.ArmorName = x.ArmorName;
                    y.ArmorType = x.ArmorType;
                    y.Description = x.Description;
                    y.HealthRequired = x.HealthRequired;
                    y.StrengthRequired = x.StrengthRequired;
                    y.AgilityRequired = x.AgilityRequired;
                    y.Special = x.Special;
                    y.MagicRequired = x.MagicRequired;
                    y.PhysicalBlocking = x.PhysicalBlocking;
                    y.PhysicalResistance = x.PhysicalResistance;
                    y.MagicalBlocking = x.MagicalBlocking;
                    y.MagicalResistance = x.MagicalResistance;
                    if (x.IsEquipped)
                    {
                        model.CharacterDetail.Health += x.Health;
                        model.CharacterDetail.Strength += x.Strength;
                        model.CharacterDetail.Instinct += x.Instinct;
                        model.CharacterDetail.Agility += x.Agility;
                        model.CharacterDetail.Intelligence += x.Intelligence;
                        model.CharacterDetail.Charisma += x.Charisma;

                        model.CharacterDetail.HitPoints += x.HitPoints;
                        model.CharacterDetail.Sanity += x.Sanity;
                        model.CharacterDetail.Dodge += x.Dodge;
                        model.CharacterDetail.Reaction += x.Reaction;
                        model.CharacterDetail.Magic += x.Magic;
                        model.CharacterDetail.BaseProwess += x.BaseProwess;
                        model.CharacterDetail.Fate += x.Fate;

                        model.CharacterDetail.Endurance += x.Endurance;
                        model.CharacterDetail.Constitution += x.Constitution;
                        model.CharacterDetail.Athletics += x.Athletics;
                        model.CharacterDetail.Tenacity += x.Tenacity;
                        model.CharacterDetail.Acrobatics += x.Acrobatics;
                        model.CharacterDetail.SleightOfHand += x.SleightOfHand;
                        model.CharacterDetail.Sneak += x.Sneak;
                        model.CharacterDetail.Willpower += x.Willpower;
                        model.CharacterDetail.Investigation += x.Investigation;
                        model.CharacterDetail.Knowledge += x.Knowledge;
                        model.CharacterDetail.Bravery += x.Bravery;
                        model.CharacterDetail.Pilotry += x.Pilotry;
                        model.CharacterDetail.Insight += x.Insight;
                        model.CharacterDetail.Perception += x.Perception;
                        model.CharacterDetail.Survival += x.Survival;
                        model.CharacterDetail.Faith += x.Faith;
                        model.CharacterDetail.Deception += x.Deception;
                        model.CharacterDetail.Diplomacy += x.Diplomacy;
                        model.CharacterDetail.Intimidation += x.Intimidation;
                        model.CharacterDetail.Performance += x.Performance;
                        model.CharacterDetail.Seduction += x.Seduction;
                    }
                };
                model.WardrobeItems.Add(y);
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "New Character";

            List<string> magicTypes = new List<string>()
            {
                "charisma",
                "intelligence",
                "instinct"
            };
            var magicQuery = from o in magicTypes
                             select new SelectListItem()
                             {
                                 Value = o,
                                 Text = o,
                             };
            ViewBag.MagicType = magicQuery.ToList();

            List<string> prowessTypes = new List<string>()
            {
                "agility",
                "strength"
            };
            var prowessQuery = from o in prowessTypes
                               select new SelectListItem()
                               {
                                   Value = o,
                                   Text = o
                               };
            ViewBag.ProwessType = prowessQuery.ToList();

            var service = CreateCharacterService();
            var detail = service.GetEditCharacterById(id);
            var model =
                new CharacterEdit
                {
                    CharacterId = detail.CharacterId,
                    CharacterName = detail.CharacterName,
                    Race = detail.Race,
                    CharacterLevel = detail.CharacterLevel,
                    Age = detail.Age,
                    Gender = detail.Gender,
                    Allignment = detail.Allignment,
                    Health = detail.Health,
                    Strength = detail.Strength,
                    Instinct = detail.Instinct,
                    Agility = detail.Agility,
                    Intelligence = detail.Intelligence,
                    Charisma = detail.Charisma,
                    MagicType = detail.MagicType,
                    ProwessType = detail.ProwessType,

                    HitPoints = detail.HitPoints,
                    Sanity = detail.Sanity,
                    Dodge = detail.Dodge,
                    Reaction = detail.Reaction,
                    BaseProwess = detail.BaseProwess,
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
            if (detail.CharacterLevel < 3)
            {
                model.Proficiency = 2;
            }
            else if (detail.CharacterLevel < 8)
            {
                model.Proficiency = 3;
            }
            else if (detail.CharacterLevel < 13)
            {
                model.Proficiency = 4;
            }
            else if (detail.CharacterLevel < 18)
            {
                model.Proficiency = 5;
            }
            else if (detail.CharacterLevel < 18)
            {
                model.Proficiency = 6;
            }
            else if (detail.CharacterLevel >= 20)
            {
                model.Proficiency = 7;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CharacterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCharacterService();
            if (service.UpdateCharacter(model))
            {
                TempData["SaveResult"] = "Your character was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your character could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateCharacterService();
            svc.DeleteCharacter(id);

            TempData["SaveResult"] = "Your character was deleted";

            return RedirectToAction("Index");
        }
    }
}