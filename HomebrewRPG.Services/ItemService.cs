using HomebrewRPG.Data;
using HomebrewRPG.Models;
using HomebrewRPG.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class ItemService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public ItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    OwnerId = _userId,
                    ItemName = model.ItemName,
                    Description = model.Description,
                    IsConsumable = model.IsConsumable
                };
            _ctx.Items.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            var query =
                _ctx
                    .Items
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new ItemListItem
                            {
                                ItemId = e.ItemId,
                                ItemName = e.ItemName,
                                Description = e.Description,
                                IsConsumable = e.IsConsumable
                            }
                    );
            return query.ToArray();
        }

        public ItemDetail GetItemById(int id)
        {
            var entity =
                _ctx
                    .Items
                    .Single(e => e.ItemId == id && e.OwnerId == _userId);
            return
                new ItemDetail
                {
                    ItemId = entity.ItemId,
                    ItemName = entity.ItemName,
                    Description = entity.Description,
                    IsConsumable = entity.IsConsumable
                };
        }

        public bool UpdateItem(ItemEdit model)
        {
            var entity =
                _ctx
                    .Items
                    .Single(e => e.ItemId == model.ItemId && e.OwnerId == _userId);
            entity.ItemId = model.ItemId;
            entity.ItemName = model.ItemName;
            entity.Description = model.Description;
            entity.IsConsumable = model.IsConsumable;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteItem(int itemId)
        {
            var entity =
                _ctx
                    .Items
                    .Single(e => e.ItemId == itemId && e.OwnerId == _userId);
            _ctx.Items.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
