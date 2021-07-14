using HomebrewRPG.Data;
using HomebrewRPG.Models.CharacterSpell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class CharacterSpellService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public CharacterSpellService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacterSpell(CharacterSpellCreate model)
        {
            var entity =
                new CharacterSpell()
                {
                    OwnerId = _userId,
                    CharacterId = model.CharacterId,
                    SpellId = model.SpellId,
                };
            _ctx.CharacterSpells.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CharacterSpellDetail> GetCharacterSpellsByCharacterId(int id)
        {
            var query =
                _ctx
                    .CharacterSpells
                    .Where(e => e.CharacterId == id && e.OwnerId == _userId)
                    .Select(
                        e =>
                            new CharacterSpellDetail
                            {
                                CharacterSpellId = e.CharacterSpellId,
                                CharacterId = e.CharacterId,
                                SpellId = e.SpellId,
                                SpellDescription = e.Spell.SpellDescription,
                                SpellEffect = e.Spell.SpellEffect,
                                Range = e.Spell.Range,
                                SpellDC = e.Spell.SpellDC,
                                SpellType = e.Spell.SpellType,
                                SpellName = e.Spell.SpellName,
                                
                            }
                    );
            return query.ToArray();
        }

        public CharacterSpellDetail GetCharacterSpellById(int id)
        {
            var entity =
                _ctx
                    .CharacterSpells
                    .Single(e => e.CharacterSpellId == id && e.OwnerId == _userId);
            CharacterSpellDetail detail =
                new CharacterSpellDetail
                {
                    CharacterSpellId = entity.CharacterSpellId,
                    CharacterId = entity.CharacterId,
                    SpellId = entity.SpellId,
                    SpellName = entity.Spell.SpellName,
                    SpellDescription = entity.Spell.SpellDescription
                };
            return detail;
        }

        public bool UpdateCharacterSpell(CharacterSpellEdit model)
        {
            var entity =
                _ctx
                    .CharacterSpells
                    .Single(e => e.CharacterSpellId == model.CharacterSpellId && e.OwnerId == _userId);

            entity.CharacterSpellId = model.CharacterSpellId;
            entity.CharacterId = model.CharacterId;
            entity.SpellId = model.SpellId;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteCharacterSpell(int characterItemId)
        {
            var entity =
                _ctx
                    .CharacterSpells
                    .Single(e => e.CharacterSpellId == characterItemId && e.OwnerId == _userId);
            _ctx.CharacterSpells.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
