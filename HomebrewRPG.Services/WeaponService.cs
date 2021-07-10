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
                    ProwessBonus = model.ProwessBonus,
                    Range = model.Range,
                    CriticalRange = model.CriticalRange,
                    Special = model.Special,
                    Parrying = model.Parrying,
                    PhysicalBlocking = model.PhysicalBlocking,
                    MagicalBlocking = model.MagicalBlocking,
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
                    ProwessBonus = entity.ProwessBonus,
                    Range = entity.Range,
                    CriticalRange = entity.CriticalRange,
                    Special = entity.Special,
                    Parrying = entity.Parrying,
                    PhysicalBlocking = entity.PhysicalBlocking,
                    MagicalBlocking = entity.MagicalBlocking
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
            entity.ProwessBonus = model.ProwessBonus;
            entity.Range = model.Range;
            entity.CriticalRange = model.CriticalRange;
            entity.Special = model.Special;
            entity.Parrying = model.Parrying;
            entity.PhysicalBlocking = model.PhysicalBlocking;
            entity.PhysicalBlocking = model.MagicalBlocking;

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
