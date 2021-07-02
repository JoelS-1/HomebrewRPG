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
                    Uses = model.Uses
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
                                Uses = e.Uses
                            }
                    );
            return query.ToArray();
        }
    }
}
