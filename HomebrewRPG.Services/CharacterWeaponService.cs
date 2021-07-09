using HomebrewRPG.Data;
using HomebrewRPG.Models.CharacterWeaponModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class CharacterWeaponService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public CharacterWeaponService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacterWeapon(CharacterWeaponCreate model)
        {
            var entity =
                new CharacterWeapon()
                {
                    OwnerId = _userId,
                    CharacterId = model.CharacterId,
                    WeaponId = model.WeaponId,
                    IsEquipped = model.IsEquipped
                };
            _ctx.CharacterWeapons.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public CharacterWeaponEdit GetCharacterWeaponById(int id)
        {
            var entity =
                _ctx
                    .CharacterWeapons
                    .Single(e => e.CharacterItemId == id && e.OwnerId == _userId);
            CharacterWeaponEdit detail =
                new CharacterWeaponEdit
                {
                    CharacterId = entity.CharacterId,
                    WeaponId = entity.WeaponId,
                    IsEquipped = entity.IsEquipped,
                };
            return detail;
        }

        public bool UpdateCharacterWeapon(CharacterWeaponEdit model)
        {
            var entity =
                _ctx
                    .CharacterWeapons
                    .Single(e => e.CharacterItemId == model.CharacterWeaponId && e.OwnerId == _userId);

            entity.CharacterId = model.CharacterId;
            entity.WeaponId = model.WeaponId;
            entity.IsEquipped = model.IsEquipped;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteCharacterWeapon(int characterWeaponId)
        {
            var entity =
                _ctx
                    .CharacterWeapons
                    .Single(e => e.CharacterItemId == characterWeaponId && e.OwnerId == _userId);
            _ctx.CharacterWeapons.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
