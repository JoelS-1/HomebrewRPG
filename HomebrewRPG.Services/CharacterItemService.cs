using HomebrewRPG.Data;
using HomebrewRPG.Models.CharacterItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class CharacterItemService
    {

        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public CharacterItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacterItem(CharacterItemCreate model)
        {
            var entity =
                new CharacterItem()
                {
                    OwnerId = _userId,
                    CharacterId = model.CharacterId,
                    ItemId = model.ItemId,
                    Quantity = model.Quantity
                };
            _ctx.CharacterItems.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CharacterItemDetail> GetCharacterItemsByCharacterId(int id)
        {
            var query =
                _ctx
                    .CharacterItems
                    .Where(e => e.CharacterId == id && e.OwnerId == _userId)
                    .Select(
                        e =>
                            new CharacterItemDetail
                            {
                                CharacterId = e.CharacterId,
                                ItemId = e.ItemId,
                                ItemName = e.Item.ItemName,
                                ItemDescription = e.Item.Description,
                                Quantity = e.Quantity
                            }
                    );
            return query.ToArray();
        }

        public CharacterItemDetail GetCharacterItemById(int id)
        {
            var entity =
                _ctx
                    .CharacterItems
                    .Single(e => e.CharacterItemId == id && e.OwnerId == _userId);
            CharacterItemDetail detail =
                new CharacterItemDetail
                {
                    CharacterId = entity.CharacterId,
                    ItemId = entity.ItemId,
                    ItemName = entity.Item.ItemName,
                    ItemDescription = entity.Item.Description,
                    Quantity = entity.Quantity
                };
            return detail;
        }

        public bool UpdateCharacterItem(CharacterItemEdit model)
        {
            var entity =
                _ctx
                    .CharacterItems
                    .Single(e => e.CharacterItemId == model.CharacterItemId && e.OwnerId == _userId);

            entity.CharacterId = model.CharacterId;
            entity.ItemId = model.ItemId;
            entity.Quantity = model.Quantity;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteCharacterItem(int characterItemId)
        {
            var entity =
                _ctx
                    .CharacterItems
                    .Single(e => e.CharacterItemId == characterItemId && e.OwnerId == _userId);
            _ctx.CharacterItems.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}