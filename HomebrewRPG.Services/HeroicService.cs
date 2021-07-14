using HomebrewRPG.Data;
using HomebrewRPG.Models;
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

        public HeroicDetail GetByHeroicId(int id)
        {
            var entity =
                _ctx
                    .Heroics
                    .Single(e => e.HeroicId == id && e.OwnerId == _userId);
            return
                new HeroicDetail
                {
                    HeroicId = entity.HeroicId,
                    HeroicName = entity.HeroicName,
                    Description = entity.Description,
                    IsPersonalHeroic = entity.IsPersonalHeroic,

                    RequiredLevel = entity.RequiredLevel,
                    RequiredHeroic = entity.RequiredHeroic,
                    RequiredAgility = entity.RequiredAgility,
                    RequiredStrength = entity.RequiredStrength,
                    RequiredInstinct = entity.RequiredInstinct,
                    RequiredIntelligence = entity.RequiredIntelligence,
                    RequiredCharisma = entity.RequiredCharisma,
                    RequiredHealth = entity.RequiredHealth
                };
        }

        public bool UpdateHeroic(HeroicEdit model)
        {
            var entity =
                _ctx
                    .Heroics
                    .Single(e => e.HeroicId == model.HeroicId && e.OwnerId == _userId);
            entity.HeroicId = model.HeroicId;
            entity.HeroicName = model.HeroicName;
            entity.Description = model.Description;
            entity.IsPersonalHeroic = model.IsPersonalHeroic;

            entity.RequiredAgility = model.RequiredAgility;
            entity.RequiredCharisma = model.RequiredCharisma;
            entity.RequiredHealth = model.RequiredHealth;
            entity.RequiredInstinct = model.RequiredInstinct;
            entity.RequiredIntelligence = model.RequiredIntelligence;
            entity.RequiredStrength = model.RequiredStrength;
            entity.RequiredLevel = model.RequiredLevel;
            entity.RequiredHeroic = model.RequiredHeroic;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteHeroic(int heroicId)
        {
            var entity =
                _ctx
                    .Heroics
                    .Single(e => e.HeroicId == heroicId && e.OwnerId == _userId);
            _ctx.Heroics.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
