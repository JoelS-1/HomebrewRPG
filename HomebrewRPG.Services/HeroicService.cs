using HomebrewRPG.Data;
using HomebrewRPG.Models.HeroicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class HeroicService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public HeroicService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHeroic(HeroicCreate model)
        {
            var entity =
                new Heroic()
                {
                    OwnerId = _userId,
                    HeroicName = model.HeroicName,
                    IsPersonalHeroic = model.IsPersonalHeroic,
                    Description = model.Description,
                    RequiredLevel = model.RequiredLevel,
                    RequiredHeroic = model.RequiredHeroic,

                    RequiredAgility = model.RequiredAgility,
                    RequiredStrength = model.RequiredStrength,
                    RequiredInstinct = model.RequiredInstinct,
                    RequiredIntelligence = model.RequiredIntelligence,
                    RequiredCharisma = model.RequiredCharisma,
                    RequiredHealth = model.RequiredHealth
                };
            _ctx.Heroics.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<HeroicListItem> GetHeroics()
        {
            var query =
                _ctx
                    .Heroics
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new HeroicListItem
                            {
                                HeroicId = e.HeroicId,
                                HeroicName = e.HeroicName,
                                Description = e.Description,
                                IsPersonalHeroic = e.IsPersonalHeroic
                            }
                    );
            return query.ToArray();
        }
    }
}
