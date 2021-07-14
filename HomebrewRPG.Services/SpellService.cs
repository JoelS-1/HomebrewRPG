using HomebrewRPG.Data;
using HomebrewRPG.Models.SpellModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class SpellService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public SpellService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSpell(SpellCreate model)
        {
            var entity =
                new Spell()
                {
                    OwnerId = _userId,
                    SpellName = model.SpellName,
                    SpellDescription = model.SpellDescription,
                    SpellEffect = model.SpellEffect,
                    SpellType = model.SpellType,
                    Range = model.Range,
                    SpellDC = model.SpellDC
                };
            _ctx.Spells.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<SpellListItem> GetSpells()
        {
            var query =
                _ctx
                    .Spells
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new SpellListItem
                            {
                                SpellId = e.SpellId,
                                SpellName = e.SpellName,
                                SpellType = e.SpellType
                            }
                    );
            return query.ToArray();
        }

        public SpellDetail GetSpellById(int id)
        {
            var entity =
                _ctx
                    .Spells
                    .Single(e => e.SpellId == id && e.OwnerId == _userId);
            return
                new SpellDetail
                {
                    SpellId = entity.SpellId,
                    SpellName = entity.SpellName,
                    SpellDescription = entity.SpellDescription,
                    SpellEffect = entity.SpellEffect,
                    SpellType = entity.SpellType,
                    Range = entity.Range,
                    SpellDC = entity.SpellDC
                };
        }

        public bool UpdateSpell(SpellEdit model)
        {
            var entity =
                _ctx
                    .Spells
                    .Single(e => e.SpellId == model.SpellId && e.OwnerId == _userId);
            entity.SpellId = model.SpellId;
            entity.SpellName = model.SpellName;
            entity.SpellDescription = model.SpellDescription;
            entity.SpellEffect = model.SpellEffect;
            entity.SpellType = model.SpellType;
            entity.Range = model.Range;
            entity.SpellDC = model.SpellDC;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteSpell(int itemId)
        {
            var entity =
                _ctx
                    .Spells
                    .Single(e => e.SpellId == itemId && e.OwnerId == _userId);
            _ctx.Spells.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
