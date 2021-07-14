using HomebrewRPG.Data;
using HomebrewRPG.Models.WardrobeItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class WardrobeItemService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public WardrobeItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWardrobeItem(WardrobeItemCreate model)
        {
            var entity =
                new WardrobeItem()
                {
                    OwnerId = _userId,
                    ArmorName = model.ArmorName,
                    ArmorType = model.ArmorType,
                    Description = model.Description,
                    HealthRequired = model.HealthRequired,
                    StrengthRequired = model.StrengthRequired,
                    AgilityRequired = model.AgilityRequired,
                    MagicRequired = model.MagicRequired,
                    Special = model.Special,
                    PhysicalResistance = model.PhysicalResistance,
                    MagicalResistance = model.MagicalResistance,
                    BlockModifier = model.BlockModifier,

                    Health = model.Health,
                    Strength = model.Strength,
                    Instinct = model.Instinct,
                    Agility = model.Agility,
                    Intelligence = model.Intelligence,
                    Charisma = model.Charisma,

                    HitPoints = model.HitPoints,
                    Sanity = model.Sanity,
                    Dodge = model.Dodge,
                    Reaction = model.Reaction,
                    Magic = model.Magic,
                    BaseProwess = model.BaseProwess,
                    Fate = model.Fate,
                    Speed = model.Speed,

                    Endurance = model.Endurance,
                    Constitution = model.Constitution,
                    Athletics = model.Athletics,
                    Tenacity = model.Tenacity,
                    Acrobatics = model.Acrobatics,
                    SleightOfHand = model.SleightOfHand,
                    Sneak = model.Sneak,
                    Willpower = model.Willpower,
                    Investigation = model.Investigation,
                    Knowledge = model.Knowledge,
                    Bravery = model.Bravery,
                    Pilotry = model.Pilotry,
                    Insight = model.Insight,
                    Perception = model.Perception,
                    Survival = model.Survival,
                    Faith = model.Faith,
                    Deception = model.Deception,
                    Diplomacy = model.Diplomacy,
                    Intimidation = model.Intimidation,
                    Performance = model.Performance,
                    Seduction = model.Seduction,
                };
            _ctx.WardrobeItems.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<WardrobeListItem> GetWardrobeListItems()
        {
            var query =
                _ctx
                    .WardrobeItems
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new WardrobeListItem
                            {
                                WardobeItemId = e.WardobeItemId,
                                ArmorName = e.ArmorName,
                                ArmorType = e.ArmorType,
                                Description = e.Description
                            }
                    );
            return query.ToArray();
        }

        public WardrobeItemDetail GetWardrobeItemById(int id)
        {
            var entity =
                _ctx
                    .WardrobeItems
                    .Single(e => e.WardobeItemId == id && e.OwnerId == _userId);
            return
                new WardrobeItemDetail
                {
                    WardobeItemId = entity.WardobeItemId,
                    ArmorName = entity.ArmorName,
                    ArmorType = entity.ArmorType,
                    Description = entity.Description,
                    HealthRequired = entity.HealthRequired,
                    StrengthRequired = entity.StrengthRequired,
                    AgilityRequired = entity.AgilityRequired,
                    MagicRequired = entity.MagicRequired,
                    Special = entity.Special,
                    PhysicalResistance = entity.PhysicalResistance,
                    MagicalResistance = entity.MagicalResistance,
                    BlockModifier = entity.BlockModifier,

                    Health = entity.Health,
                    Strength = entity.Strength,
                    Instinct = entity.Instinct,
                    Agility = entity.Agility,
                    Intelligence = entity.Intelligence,
                    Charisma = entity.Charisma,

                    HitPoints = entity.HitPoints,
                    Sanity = entity.Sanity,
                    Dodge = entity.Dodge,
                    Reaction = entity.Reaction,
                    Magic = entity.Magic,
                    BaseProwess = entity.BaseProwess,
                    Fate = entity.Fate,
                    Speed = entity.Speed,

                    Endurance = entity.Endurance,
                    Constitution = entity.Constitution,
                    Athletics = entity.Athletics,
                    Tenacity = entity.Tenacity,
                    Acrobatics = entity.Acrobatics,
                    SleightOfHand = entity.SleightOfHand,
                    Sneak = entity.Sneak,
                    Willpower = entity.Willpower,
                    Investigation = entity.Investigation,
                    Knowledge = entity.Knowledge,
                    Bravery = entity.Bravery,
                    Pilotry = entity.Pilotry,
                    Insight = entity.Insight,
                    Perception = entity.Perception,
                    Survival = entity.Survival,
                    Faith = entity.Faith,
                    Deception = entity.Deception,
                    Diplomacy = entity.Diplomacy,
                    Intimidation = entity.Intimidation,
                    Performance = entity.Performance,
                    Seduction = entity.Seduction,
                };
        }

        public bool UpdateWardrobeItem(WardrobeItemEdit model)
        {
            var entity =
                _ctx
                    .WardrobeItems
                    .Single(e => e.WardobeItemId == model.WardobeItemId && e.OwnerId == _userId);
            entity.WardobeItemId = model.WardobeItemId;
            entity.ArmorName = model.ArmorName;
            entity.ArmorType = model.ArmorType;
            entity.Description = model.Description;
            entity.HealthRequired = model.HealthRequired;
            entity.StrengthRequired = model.StrengthRequired;
            entity.AgilityRequired = model.AgilityRequired;
            entity.MagicRequired = model.MagicRequired;
            entity.Special = model.Special;
            entity.PhysicalResistance = model.PhysicalResistance;
            entity.MagicalResistance = model.MagicalResistance;
            entity.BlockModifier = model.BlockModifier;

            entity.Health = model.Health;
            entity.Strength = model.Strength;
            entity.Instinct = model.Instinct;
            entity.Agility = model.Agility;
            entity.Intelligence = model.Intelligence;
            entity.Charisma = model.Charisma;

            entity.Dodge = model.Dodge;
            entity.Reaction = model.Reaction;
            entity.Magic = model.Magic;
            entity.BaseProwess = model.BaseProwess;
            entity.Fate = model.Fate;
            entity.Speed = model.Speed;

            entity.Endurance = model.Endurance;
            entity.Constitution = model.Constitution;
            entity.Athletics = model.Athletics;
            entity.Tenacity = model.Tenacity;
            entity.Acrobatics = model.Acrobatics;
            entity.SleightOfHand = model.SleightOfHand;
            entity.Sneak = model.Sneak;
            entity.Willpower = model.Willpower;
            entity.Investigation = model.Investigation;
            entity.Knowledge = model.Knowledge;
            entity.Bravery = model.Bravery;
            entity.Pilotry = model.Pilotry;
            entity.Insight = model.Insight;
            entity.Perception = model.Perception;
            entity.Survival = model.Survival;
            entity.Faith = model.Faith;
            entity.Deception = model.Deception;
            entity.Diplomacy = model.Diplomacy;
            entity.Intimidation = model.Intimidation;
            entity.Performance = model.Performance;
            entity.Seduction = model.Seduction;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteWardrobeItem(int id)
        {
            var entity =
                _ctx
                    .WardrobeItems
                    .Single(e => e.WardobeItemId == e.WardobeItemId && e.OwnerId == _userId);
            _ctx.WardrobeItems.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
