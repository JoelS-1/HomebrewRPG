﻿using HomebrewRPG.Data;
using HomebrewRPG.Models.CharacterWardrobeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class CharacterWardrobeService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public CharacterWardrobeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacterWardrobe(CharacterWardrobeCreate model)
        {
            var entity =
                new CharacterWardrobe()
                {
                    OwnerId = _userId,
                    CharacterId = model.CharacterId,
                    WardrobeItemId = model.WardrobeItemId,
                    IsEquipped = model.IsEquipped
                };
            _ctx.CharacterWardrobes.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        //public IEnumerable<CharacterWardrobeListItem> GetCharacterItemsByCharacterId(int id)
        //{
        //    var query =
        //        _ctx
        //            .CharacterItems
        //            .Where(e => e.CharacterId == id && e.OwnerId == _userId)
        //            .Select(
        //                e =>
        //                    new CharacterWardrobeListItem
        //                    {
        //                        CharacterId = e.CharacterId,
        //                        ItemId = e.ItemId,
        //                        ItemName = e.Item.ItemName,
        //                        ItemDescription = e.Item.Description,
        //                        Quantity = e.Quantity
        //                    }
        //            );
        //    return query.ToArray();
        //}

        public CharacterWardrobeEdit GetCharacterWardrobeById(int id)
        {
            var entity =
                _ctx
                    .CharacterWardrobes
                    .Single(e => e.CharacterWardobeId == id && e.OwnerId == _userId);
            CharacterWardrobeEdit detail =
                new CharacterWardrobeEdit
                {
                    CharacterId = entity.CharacterId,
                    WardrobeItemId = entity.WardrobeItemId,
                    IsEquipped = entity.IsEquipped,
                };
            return detail;
        }

        public bool UpdateCharacterWardrobe(CharacterWardrobeEdit model)
        {
            var entity =
                _ctx
                    .CharacterWardrobes
                    .Single(e => e.CharacterWardobeId == model.CharacterWardrobeId && e.OwnerId == _userId);

            entity.CharacterId = model.CharacterId;
            entity.WardrobeItemId = model.WardrobeItemId;
            entity.IsEquipped = model.IsEquipped;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteCharacterWardrobe(int characterWardrobeId)
        {
            var entity =
                _ctx
                    .CharacterWardrobes
                    .Single(e => e.CharacterWardobeId == characterWardrobeId && e.OwnerId == _userId);
            _ctx.CharacterWardrobes.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}