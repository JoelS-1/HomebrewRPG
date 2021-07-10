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
                    MagicalResistance = entity.MagicalResistance
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
