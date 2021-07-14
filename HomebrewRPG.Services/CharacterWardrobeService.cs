using HomebrewRPG.Data;
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

        public IEnumerable<CharacterWardrobeDetail> GetCharacterWardrobeListByCharacterId(int id)
        {
            var query =
                _ctx
                    .CharacterWardrobes
                    .Where(e => e.CharacterId == id && e.OwnerId == _userId)
                    .Select(
                        e =>
                            new CharacterWardrobeDetail
                            {
                                CharacterId = e.CharacterId,
                                CharacterWardrobeId = e.CharacterWardobeId,
                                WardrobeItemId = e.WardrobeItemId,
                                IsEquipped = e.IsEquipped,

                                ArmorName = e.WardrobeItem.ArmorName,
                                ArmorType = e.WardrobeItem.ArmorType,
                                Description = e.WardrobeItem.Description,
                                HealthRequired = e.WardrobeItem.HealthRequired,
                                StrengthRequired = e.WardrobeItem.StrengthRequired,
                                AgilityRequired = e.WardrobeItem.AgilityRequired,
                                MagicRequired = e.WardrobeItem.MagicRequired,
                                Special = e.WardrobeItem.Special,
                                PhysicalResistance = e.WardrobeItem.PhysicalResistance,
                                MagicalResistance = e.WardrobeItem.MagicalResistance,

                                Health = e.WardrobeItem.Health,
                                Strength = e.WardrobeItem.Strength,
                                Instinct = e.WardrobeItem.Instinct,
                                Agility = e.WardrobeItem.Agility,
                                Intelligence = e.WardrobeItem.Intelligence,
                                Charisma = e.WardrobeItem.Charisma,

                                HitPoints = e.WardrobeItem.HitPoints,
                                Sanity = e.WardrobeItem.Sanity,
                                Dodge = e.WardrobeItem.Dodge,
                                Reaction = e.WardrobeItem.Reaction,
                                Magic = e.WardrobeItem.Magic,
                                BaseProwess = e.WardrobeItem.BaseProwess,
                                Fate = e.WardrobeItem.Fate,
                                Speed = e.WardrobeItem.Speed,

                                Endurance = e.WardrobeItem.Endurance,
                                Constitution = e.WardrobeItem.Constitution,
                                Athletics = e.WardrobeItem.Athletics,
                                Tenacity = e.WardrobeItem.Tenacity,
                                Acrobatics = e.WardrobeItem.Acrobatics,
                                SleightOfHand = e.WardrobeItem.SleightOfHand,
                                Sneak = e.WardrobeItem.Sneak,
                                Willpower = e.WardrobeItem.Willpower,
                                Investigation = e.WardrobeItem.Investigation,
                                Knowledge = e.WardrobeItem.Knowledge,
                                Bravery = e.WardrobeItem.Bravery,
                                Pilotry = e.WardrobeItem.Pilotry,
                                Insight = e.WardrobeItem.Insight,
                                Perception = e.WardrobeItem.Perception,
                                Survival = e.WardrobeItem.Survival,
                                Faith = e.WardrobeItem.Faith,
                                Deception = e.WardrobeItem.Deception,
                                Diplomacy = e.WardrobeItem.Diplomacy,
                                Intimidation = e.WardrobeItem.Intimidation,
                                Performance = e.WardrobeItem.Performance,
                                Seduction = e.WardrobeItem.Seduction,
                            }
                    );
            return query.ToArray();
        }

        public CharacterWardrobeDetail GetCharacterWardrobeById(int id)
        {
            var entity =
                _ctx
                    .CharacterWardrobes
                    .Single(e => e.CharacterWardobeId == id && e.OwnerId == _userId);
            CharacterWardrobeDetail detail =
                new CharacterWardrobeDetail
                {
                    CharacterWardrobeId = entity.CharacterWardobeId,
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

            entity.CharacterWardobeId = model.CharacterWardrobeId;
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
