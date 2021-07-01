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
    }
}
