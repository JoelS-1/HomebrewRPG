using HomebrewRPG.Data;
using HomebrewRPG.Models.EssentialSkillsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class EssentialSkillsService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public EssentialSkillsService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<EssentialSkillsList> GetSkills()
        {
            var query =
                _ctx
                    .EssentialSkillsDb
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new EssentialSkillsList
                            {
                                CharacterId = e.CharacterId,
                                EssentialSkillsId = e.EssentialSkillsId
                            }
                    );
            return query.ToArray();
        }

        public bool CreateEssentialSkills(EssentialSkillsCreate model)
        {
            var entity =
                new EssentialSkills()
                {
                    OwnerId = _userId,
                    HitPoints = model.HitPoints,
                    Sanity = model.Sanity,
                    Dodge = model.Dodge,
                    Reaction = model.Reaction,
                    BaseProwess = model.BaseProwess,
                    Magic = model.Magic,
                    Fate = model.Fate,
                    Speed = model.Speed,
                    Endurance = model.Endurance,
                    Constitution = model.Constitution,
                    Athletics = model.Athletics,
                    Tenacity = model.Tenacity,
                    Acrobatics = model.Acrobatics,
                    SleightOfHand = model.SleightOfHand,
                    Sneak = model.Sneak,
                    Willpower = model.Willpower,
                    Investigation = model.Investigation,
                    Knowledge = model.Knowledge,
                    Bravery = model.Bravery,
                    Pilotry = model.Pilotry,
                    Insight = model.Insight,
                    Perception = model.Perception,
                    Survival = model.Survival,
                    Faith = model.Faith,
                    Deception = model.Deception,
                    Diplomacy = model.Diplomacy,
                    Intimidation = model.Intimidation,
                    Performance = model.Performance,
                    Seduction = model.Seduction
                };
            _ctx.EssentialSkillsDb.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public EssentialSkillsDetail GetSkillsById(int id)
        {
            var entity =
                _ctx
                    .EssentialSkillsDb
                    .Single(e => e.EssentialSkillsId == id && e.OwnerId == _userId);
            return
                new EssentialSkillsDetail
                {
                    EssentialSkillsId = entity.EssentialSkillsId,
                    HitPoints = entity.HitPoints,
                    Sanity = entity.Sanity,
                    Dodge = entity.Dodge,
                    Reaction = entity.Reaction,
                    BaseProwess = entity.BaseProwess,
                    Magic = entity.Magic,
                    Fate = entity.Fate,
                    Speed = entity.Speed,
                    Endurance = entity.Endurance,
                    Constitution = entity.Constitution,
                    Athletics = entity.Athletics,
                    Tenacity = entity.Tenacity,
                    Acrobatics = entity.Acrobatics,
                    SleightOfHand = entity.SleightOfHand,
                    Sneak = entity.Sneak,
                    Willpower = entity.Willpower,
                    Investigation = entity.Investigation,
                    Knowledge = entity.Knowledge,
                    Bravery = entity.Bravery,
                    Pilotry = entity.Pilotry,
                    Insight = entity.Insight,
                    Perception = entity.Perception,
                    Survival = entity.Survival,
                    Faith = entity.Faith,
                    Deception = entity.Deception,
                    Diplomacy = entity.Diplomacy,
                    Intimidation = entity.Intimidation,
                    Performance = entity.Performance,
                    Seduction = entity.Seduction,
                    DamageResistance = entity.DamageResistance,
                    MagicResistance = entity.MagicResistance
                };
        }
    }
}
