using HomebrewRPG.Data;
using HomebrewRPG.Models.WeaponModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class WeaponService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public WeaponService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWeapon(WeaponCreate model)
        {
            var entity =
                new Weapon()
                {
                    OwnerId = _userId,
                    WeaponName = model.WeaponName,
                    Description = model.Description,
                    WeaponType = model.WeaponType,
                    DamageDice = model.DamageDice,
                    DamageModifier = model.DamageModifier,
                    Range = model.Range,
                    CriticalRange = model.CriticalRange,
                    Special = model.Special,
                    Parrying = model.Parrying,
                    PhysicalBlocking = model.PhysicalBlocking,
                    MagicalBlocking = model.MagicalBlocking,

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
                    ProwessBonus = model.ProwessBonus,
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
            _ctx.Weapons.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<WeaponListItem> GetWeapons()
        {
            var query =
                _ctx
                    .Weapons
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new WeaponListItem
                            {
                                WeaponId = e.WeaponId,
                                WeaponName = e.WeaponName,
                                Description = e.Description,
                                WeaponType = e.WeaponType
                            }
                    );
            return query.ToArray();
        }

        public WeaponDetail GetWeaponById(int id)
        {
            var entity =
                _ctx
                    .Weapons
                    .Single(e => e.WeaponId == id && e.OwnerId == _userId);
            return
                new WeaponDetail
                {
                    WeaponId = entity.WeaponId,
                    WeaponName = entity.WeaponName,
                    Description = entity.Description,
                    WeaponType = entity.WeaponType,
                    DamageDice = entity.DamageDice,
                    DamageModifier = entity.DamageModifier,
                    Range = entity.Range,
                    CriticalRange = entity.CriticalRange,
                    Special = entity.Special,
                    Parrying = entity.Parrying,
                    PhysicalBlocking = entity.PhysicalBlocking,
                    MagicalBlocking = entity.MagicalBlocking,

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
                    ProwessBonus = entity.ProwessBonus,
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

        public bool UpdateWeapon(WeaponEdit model)
        {
            var entity =
                _ctx
                    .Weapons
                    .Single(e => e.WeaponId == model.WeaponId && e.OwnerId == _userId);
            entity.WeaponId = model.WeaponId;
            entity.WeaponName = model.WeaponName;
            entity.Description = model.Description;
            entity.WeaponType = model.WeaponType;
            entity.DamageDice = model.DamageDice;
            entity.DamageModifier = model.DamageModifier;
            entity.Range = model.Range;
            entity.CriticalRange = model.CriticalRange;
            entity.Special = model.Special;
            entity.Parrying = model.Parrying;
            entity.PhysicalBlocking = model.PhysicalBlocking;
            entity.PhysicalBlocking = model.MagicalBlocking;

            entity.Dodge = model.Dodge;
            entity.Reaction = model.Reaction;
            entity.Magic = model.Magic;
            entity.ProwessBonus = model.ProwessBonus;
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

        public bool DeleteWeapon(int weaponId)
        {
            var entity =
                _ctx
                    .Weapons
                    .Single(e => e.WeaponId == weaponId && e.OwnerId == _userId);
            _ctx.Weapons.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
