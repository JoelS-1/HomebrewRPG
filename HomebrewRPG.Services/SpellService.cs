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
    }
}
