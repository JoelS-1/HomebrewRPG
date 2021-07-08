using HomebrewRPG.Data;
using HomebrewRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{

    public class CharacterService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    OwnerId = _userId,
                    CharacterName = model.CharacterName,
                    Race = model.Race,
                    CharacterLevel = model.CharacterLevel,
                    Age = model.Age,
                    Gender = model.Gender,
                    Allignment = model.Allignment,
                    Health = model.Health,
                    Strength = model.Strength,
                    Instinct = model.Instinct,
                    Agility = model.Agility,
                    Intelligence = model.Intelligence,
                    Charisma = model.Charisma,
                    MagicType = model.MagicType,
                    ProwessType = model.ProwessType,

                    HitPoints = 0,
                    Sanity = 0,
                    Dodge = model.Dodge,
                    Reaction = model.Reaction,
                    Magic = model.Magic,
                    BaseProwess = model.BaseProwess,
                       
                    Fate = 0,
                    Speed = 0,

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
                    Seduction = model.Seduction,
                };

            if (model.CharacterLevel < 3)
            {
                entity.Proficiency = 2;
            }
            else if (model.CharacterLevel < 8)
            {
                entity.Proficiency = 3;
            }
            else if (model.CharacterLevel < 13)
            {
                entity.Proficiency = 4;
            }
            else if (model.CharacterLevel < 18)
            {
                entity.Proficiency = 5;
            }
            else if (model.CharacterLevel < 18)
            {
                entity.Proficiency = 6;
            }
            else if (model.CharacterLevel >= 20)
            {
                entity.Proficiency = 7;
            }

            _ctx.Characters.Add(entity);
                return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            var query =
                _ctx
                    .Characters
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new CharacterListItem
                            {
                                CharacterId = e.CharacterId,
                                CharacterName = e.CharacterName,
                                Race = e.Race,
                                CharacterLevel = e.CharacterLevel,
                            }
                    );
            return query.ToArray();
        }

        public CharacterDetail GetCharacterById(int id)
        {
            var entity =
                _ctx
                    .Characters
                    .Single(e => e.CharacterId == id && e.OwnerId == _userId);
            CharacterDetail detail =
                new CharacterDetail
                {
                    CharacterId = entity.CharacterId,
                    CharacterName = entity.CharacterName,
                    Race = entity.Race,
                    CharacterLevel = entity.CharacterLevel,
                    Age = entity.Age,
                    Gender = entity.Gender,
                    Allignment = entity.Allignment,
                    Health = entity.Health,
                    Strength = entity.Strength,
                    Instinct = entity.Instinct,
                    Agility = entity.Agility,
                    Intelligence = entity.Intelligence,
                    Charisma = entity.Charisma,
                    MagicType = entity.MagicType,
                    ProwessType = entity.ProwessType,
                    Proficiency = entity.Proficiency,

                    HitPoints = 10 + (entity.Health * 2),
                    Sanity = 10 + (entity.Intelligence * 2),
                    Dodge = entity.Dodge + (entity.Agility * 2),
                    Reaction = entity.Reaction + (entity.Instinct * 2),
                    Fate = 1 + entity.Charisma,
                    Speed = 6 + entity.Agility,

                    Endurance = entity.Endurance + entity.Proficiency + (entity.Health * 3),
                    Constitution = entity.Constitution + entity.Proficiency + (entity.Health * 3),
                    Athletics = entity.Athletics + entity.Proficiency + (entity.Strength * 3),
                    Tenacity = entity.Tenacity + entity.Proficiency + (entity.Strength * 3),
                    Acrobatics = entity.Acrobatics + entity.Proficiency + (entity.Agility * 3),
                    SleightOfHand = entity.SleightOfHand + entity.Proficiency + (entity.Agility * 3),
                    Sneak = entity.Sneak + entity.Proficiency + (entity.Agility * 3),
                    Willpower = entity.Willpower + entity.Proficiency + (entity.Intelligence * 3),
                    Investigation = entity.Investigation + entity.Proficiency + (entity.Intelligence * 3),
                    Knowledge = entity.Knowledge + entity.Proficiency + (entity.Intelligence * 3),
                    Bravery = entity.Bravery + entity.Proficiency + (entity.Instinct * 3),
                    Pilotry = entity.Pilotry + entity.Proficiency + (entity.Instinct * 3),
                    Insight = entity.Insight + entity.Proficiency + (entity.Instinct * 3),
                    Perception = entity.Perception + entity.Proficiency + (entity.Instinct * 3),
                    Survival = entity.Survival + entity.Proficiency + (entity.Instinct * 3),
                    Faith = entity.Faith + entity.Proficiency + (entity.Charisma * 3),
                    Deception = entity.Deception + entity.Proficiency + (entity.Charisma * 3),
                    Diplomacy = entity.Diplomacy + entity.Proficiency + (entity.Charisma * 3),
                    Intimidation = entity.Intimidation + entity.Proficiency + (entity.Charisma * 3),
                    Performance = entity.Performance + entity.Proficiency + (entity.Charisma * 3),
                    Seduction = entity.Seduction + entity.Proficiency + (entity.Charisma * 3)
                };
            if (entity.ProwessType == "strength")
            {
                detail.BaseProwess = entity.BaseProwess + (detail.Strength * 2);
            }
            else if (entity.ProwessType == "agility")
            {
                detail.BaseProwess = entity.BaseProwess + (detail.Agility * 2);
            }
            else
            {
                detail.BaseProwess = 0;
            }
            if (entity.MagicType == "intelligence")
            {
                detail.Magic = entity.Magic + (detail.Intelligence * 2);
            }
            else if (entity.MagicType == "charisma")
            {
                detail.Magic = entity.Magic + (detail.Charisma * 2);
            }
            else if (entity.MagicType == "instinct")
            {
                detail.Magic = entity.Magic + (detail.Instinct * 2);
            }
            else
            {
                detail.Magic = 0;
            }
            return detail;

        }

        public CharacterEdit GetEditCharacterById(int id)
        {
            var entity =
                _ctx
                    .Characters
                    .Single(e => e.CharacterId == id && e.OwnerId == _userId);
            return
                new CharacterEdit
                {
                    CharacterId = entity.CharacterId,
                    CharacterName = entity.CharacterName,
                    Race = entity.Race,
                    CharacterLevel = entity.CharacterLevel,
                    Age = entity.Age,
                    Gender = entity.Gender,
                    Allignment = entity.Allignment,
                    Health = entity.Health,
                    Strength = entity.Strength,
                    Instinct = entity.Instinct,
                    Agility = entity.Agility,
                    Intelligence = entity.Intelligence,
                    Charisma = entity.Charisma,
                    MagicType = entity.MagicType,
                    ProwessType = entity.ProwessType,
                    Proficiency = entity.Proficiency,

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
                };
        }

        public bool UpdateCharacter(CharacterEdit model)
        {
            var entity =
                _ctx
                    .Characters
                    .Single(e => e.CharacterId == model.CharacterId && e.OwnerId == _userId);

            entity.CharacterId = model.CharacterId;
            entity.CharacterName = model.CharacterName;
            entity.Race = model.Race;
            entity.CharacterLevel = model.CharacterLevel;
            entity.Age = model.Age;
            entity.Gender = model.Gender;
            entity.Allignment = model.Allignment;
            entity.Health = model.Health;
            entity.Strength = model.Strength;
            entity.Instinct = model.Instinct;
            entity.Agility = model.Agility;
            entity.Intelligence = model.Intelligence;
            entity.Charisma = model.Charisma;
            entity.MagicType = model.MagicType;
            entity.ProwessType = model.ProwessType;

            entity.Dodge = model.Dodge;
            entity.Reaction = model.Reaction;
            entity.Magic = model.Magic;
            entity.BaseProwess = model.BaseProwess;

            entity.Endurance = model.Endurance;
            entity.Constitution = model.Constitution;
            entity.Athletics = model.Athletics;
            entity.Tenacity = model.Tenacity;
            entity.Acrobatics = model.Acrobatics;
            entity.SleightOfHand = model.SleightOfHand;
            entity.Sneak = model.Sneak;
            entity.Willpower = model.Willpower;
            entity.Investigation = model.Investigation;
            entity.Knowledge = model.Knowledge;
            entity.Bravery = model.Bravery;
            entity.Pilotry = model.Pilotry;
            entity.Insight = model.Insight;
            entity.Perception = model.Perception;
            entity.Survival = model.Survival;
            entity.Faith = model.Faith;
            entity.Deception = model.Deception;
            entity.Diplomacy = model.Diplomacy;
            entity.Intimidation = model.Intimidation;
            entity.Performance = model.Performance;
            entity.Seduction = model.Seduction;

            if (model.CharacterLevel < 3)
            {
                entity.Proficiency = 2;
            }
            else if (model.CharacterLevel < 8)
            {
                entity.Proficiency = 3;
            }
            else if (model.CharacterLevel < 13)
            {
                entity.Proficiency = 4;
            }
            else if (model.CharacterLevel < 18)
            {
                entity.Proficiency = 5;
            }
            else if (model.CharacterLevel < 18)
            {
                entity.Proficiency = 6;
            }
            else if (model.CharacterLevel >= 20)
            {
                entity.Proficiency = 7;
            }



            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteCharacter(int characterId)
        {
            var entity =
                _ctx
                    .Characters
                    .Single(e => e.CharacterId == characterId && e.OwnerId == _userId);
            _ctx.Characters.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
