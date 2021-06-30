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
            Character characterModel =
                _ctx.Characters.Single(e => e.CharacterId == model.CharacterId);

            var entity =
                new EssentialSkills()
                {
                    OwnerId = _userId,
                    CharacterId = model.CharacterId,
                    HitPoints = 10 + (characterModel.Health * 2),
                    Sanity = 10 + (characterModel.Intelligence * 2),
                    Dodge = 10 + model.Dodge + (characterModel.Agility * 2),
                    Reaction = 10 + model.Reaction +(characterModel.Instinct * 2),
                    Fate = 1 + characterModel.Charisma,
                    Speed = 6 + characterModel.Agility,

                    Endurance = model.Endurance + characterModel.Proficiency + (characterModel.Health * 3),
                    Constitution = model.Constitution + characterModel.Proficiency + (characterModel.Health * 3),
                    Athletics = model.Athletics + characterModel.Proficiency + (characterModel.Strength * 3),
                    Tenacity = model.Tenacity + characterModel.Proficiency + (characterModel.Strength * 3),
                    Acrobatics = model.Acrobatics + characterModel.Proficiency + (characterModel.Agility * 3),
                    SleightOfHand = model.SleightOfHand + characterModel.Proficiency + (characterModel.Agility * 3),
                    Sneak = model.Sneak + characterModel.Proficiency + (characterModel.Agility * 3),
                    Willpower = model.Willpower + characterModel.Proficiency + (characterModel.Intelligence * 3),
                    Investigation = model.Investigation + characterModel.Proficiency + (characterModel.Intelligence * 3),
                    Knowledge = model.Knowledge + characterModel.Proficiency + (characterModel.Intelligence * 3),
                    Bravery = model.Bravery + characterModel.Proficiency + (characterModel.Instinct * 3),
                    Pilotry = model.Pilotry + characterModel.Proficiency + (characterModel.Instinct * 3),
                    Insight = model.Insight + characterModel.Proficiency + (characterModel.Instinct * 3),
                    Perception = model.Perception + characterModel.Proficiency + (characterModel.Instinct * 3),
                    Survival = model.Survival + characterModel.Proficiency + (characterModel.Instinct * 3),
                    Faith = model.Faith + characterModel.Proficiency + (characterModel.Charisma * 3),
                    Deception = model.Deception + characterModel.Proficiency + (characterModel.Charisma * 3),
                    Diplomacy = model.Diplomacy + characterModel.Proficiency + (characterModel.Charisma * 3),
                    Intimidation = model.Intimidation + characterModel.Proficiency + (characterModel.Charisma * 3),
                    Performance = model.Performance + characterModel.Proficiency + (characterModel.Charisma * 3),
                    Seduction = model.Seduction + characterModel.Proficiency + (characterModel.Charisma * 3)
                };
            if(characterModel.ProwessType == "Strength")
            {
                entity.BaseProwess = 10 + (characterModel.Strength * 2);
            }
            else if(characterModel.ProwessType == "Agility")
            {
                entity.BaseProwess = 10 + (characterModel.Agility * 2);
            }
            else
            {
                entity.BaseProwess = 10;
            }
            if (characterModel.MagicType == "Intelligence")
            {
                entity.Magic = 10 + (characterModel.Intelligence * 2);
            }
            else if(characterModel.MagicType == "Charisma")
            {
                entity.Magic = 10 + (characterModel.Charisma * 2);
            }
            else if (characterModel.MagicType == "Instinct")
            {
                entity.Magic = 10 + (characterModel.Instinct * 2);
            }
            else
            {
                entity.Magic = 0;
            }

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
