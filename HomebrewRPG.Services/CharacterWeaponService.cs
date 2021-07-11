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

        public IEnumerable<CharacterWeaponDetail> GetCharacterWeaponsByCharacterId(int id)
        {
            var query =
                _ctx
                    .CharacterWeapons
                    .Where(e => e.CharacterId == id && e.OwnerId == _userId)
                    .Select(
                        e =>
                            new CharacterWeaponDetail
                            {
                                CharacterId = e.CharacterId,
                                CharacterWeaponId = e.CharacterWeaponId,
                                WeaponId = e.WeaponId,
                                IsEquipped = e.IsEquipped,

                                WeaponName = e.Weapon.WeaponName,
                                Description = e.Weapon.Description,
                                WeaponType = e.Weapon.WeaponType,
                                DamageDice = e.Weapon.DamageDice,
                                DamageModifier = e.Weapon.DamageModifier,
                                Range = e.Weapon.Range,
                                CriticalRange = e.Weapon.CriticalRange,
                                Special = e.Weapon.Special,

                                Health = e.Weapon.Health,
                                Strength = e.Weapon.Strength,
                                Instinct = e.Weapon.Instinct,
                                Agility = e.Weapon.Agility,
                                Intelligence = e.Weapon.Intelligence,
                                Charisma = e.Weapon.Charisma,

                                HitPoints = e.Weapon.HitPoints,
                                Sanity = e.Weapon.Sanity,
                                Dodge = e.Weapon.Dodge,
                                Reaction = e.Weapon.Reaction,
                                Magic = e.Weapon.Magic,
                                ProwessBonus = e.Weapon.ProwessBonus,
                                Fate = e.Weapon.Fate,
                                Speed = e.Weapon.Speed,

                                Endurance = e.Weapon.Endurance,
                                Constitution = e.Weapon.Constitution,
                                Athletics = e.Weapon.Athletics,
                                Tenacity = e.Weapon.Tenacity,
                                Acrobatics = e.Weapon.Acrobatics,
                                SleightOfHand = e.Weapon.SleightOfHand,
                                Sneak = e.Weapon.Sneak,
                                Willpower = e.Weapon.Willpower,
                                Investigation = e.Weapon.Investigation,
                                Knowledge = e.Weapon.Knowledge,
                                Bravery = e.Weapon.Bravery,
                                Pilotry = e.Weapon.Pilotry,
                                Insight = e.Weapon.Insight,
                                Perception = e.Weapon.Perception,
                                Survival = e.Weapon.Survival,
                                Faith = e.Weapon.Faith,
                                Deception = e.Weapon.Deception,
                                Diplomacy = e.Weapon.Diplomacy,
                                Intimidation = e.Weapon.Intimidation,
                                Performance = e.Weapon.Performance,
                                Seduction = e.Weapon.Seduction,

                            }
                    );
            return query.ToArray();
        }

        public CharacterWeaponEdit GetCharacterWeaponById(int id)
        {
            var entity =
                _ctx
                    .CharacterWeapons
                    .Single(e => e.CharacterWeaponId == id && e.OwnerId == _userId);
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
                    .Single(e => e.CharacterWeaponId == model.CharacterWeaponId && e.OwnerId == _userId);

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
                    .Single(e => e.CharacterWeaponId == characterWeaponId && e.OwnerId == _userId);
            _ctx.CharacterWeapons.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
