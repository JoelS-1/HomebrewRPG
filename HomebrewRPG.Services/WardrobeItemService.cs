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
                    PhysicalBlocking = model.PhysicalBlocking,
                    MagicalBlocking = model.MagicalBlocking,
                    PhysicalResistance = model.PhysicalResistance,
                    MagicalResistance = model.MagicalResistance
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
    }
}
