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

                    HitPoints = 10 + (model.Health * 2),
                    Sanity = 10 + (model.Intelligence * 2),
                    Dodge = 10 + model.Dodge + (model.Agility * 2),
                    Reaction = 10 + model.Reaction + (model.Instinct * 2),
                    Fate = 1 + model.Charisma,
                    Speed = 6 + model.Agility,

                    Endurance = model.Endurance + model.Proficiency + (model.Health * 3),
                    Constitution = model.Constitution + model.Proficiency + (model.Health * 3),
                    Athletics = model.Athletics + model.Proficiency + (model.Strength * 3),
                    Tenacity = model.Tenacity + model.Proficiency + (model.Strength * 3),
                    Acrobatics = model.Acrobatics + model.Proficiency + (model.Agility * 3),
                    SleightOfHand = model.SleightOfHand + model.Proficiency + (model.Agility * 3),
                    Sneak = model.Sneak + model.Proficiency + (model.Agility * 3),
                    Willpower = model.Willpower + model.Proficiency + (model.Intelligence * 3),
                    Investigation = model.Investigation + model.Proficiency + (model.Intelligence * 3),
                    Knowledge = model.Knowledge + model.Proficiency + (model.Intelligence * 3),
                    Bravery = model.Bravery + model.Proficiency + (model.Instinct * 3),
                    Pilotry = model.Pilotry + model.Proficiency + (model.Instinct * 3),
                    Insight = model.Insight + model.Proficiency + (model.Instinct * 3),
                    Perception = model.Perception + model.Proficiency + (model.Instinct * 3),
                    Survival = model.Survival + model.Proficiency + (model.Instinct * 3),
                    Faith = model.Faith + model.Proficiency + (model.Charisma * 3),
                    Deception = model.Deception + model.Proficiency + (model.Charisma * 3),
                    Diplomacy = model.Diplomacy + model.Proficiency + (model.Charisma * 3),
                    Intimidation = model.Intimidation + model.Proficiency + (model.Charisma * 3),
                    Performance = model.Performance + model.Proficiency + (model.Charisma * 3),
                    Seduction = model.Seduction + model.Proficiency + (model.Charisma * 3)
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

            if (model.ProwessType == "Strength")
            {
                entity.BaseProwess = 10 + (model.Strength * 2);
            }
            else if (model.ProwessType == "Agility")
            {
                entity.BaseProwess = 10 + (model.Agility * 2);
            }
            else
            {
                entity.BaseProwess = 10;
            }
            if (model.MagicType == "Intelligence")
            {
                entity.Magic = 10 + (model.Intelligence * 2);
            }
            else if (model.MagicType == "Charisma")
            {
                entity.Magic = 10 + (model.Charisma * 2);
            }
            else if (model.MagicType == "Instinct")
            {
                entity.Magic = 10 + (model.Instinct * 2);
            }
            else
            {
                entity.Magic = 0;
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
            return
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

            entity.HitPoints = 10 + (model.Health * 2);
            entity.Sanity = 10 + (model.Intelligence * 2);
            entity.Dodge = 10 + model.Dodge + (model.Agility * 2);
            entity.Reaction = 10 + model.Reaction + (model.Instinct * 2);
            entity.Fate = 1 + model.Charisma;
            entity.Speed = 6 + model.Agility;

            entity.Endurance = model.Endurance + model.Proficiency + (model.Health * 3);
            entity.Constitution = model.Constitution + model.Proficiency + (model.Health * 3);
            entity.Athletics = model.Athletics + model.Proficiency + (model.Strength * 3);
            entity.Tenacity = model.Tenacity + model.Proficiency + (model.Strength * 3);
            entity.Acrobatics = model.Acrobatics + model.Proficiency + (model.Agility * 3);
            entity.SleightOfHand = model.SleightOfHand + model.Proficiency + (model.Agility * 3);
            entity.Sneak = model.Sneak + model.Proficiency + (model.Agility * 3);
            entity.Willpower = model.Willpower + model.Proficiency + (model.Intelligence * 3);
            entity.Investigation = model.Investigation + model.Proficiency + (model.Intelligence * 3);
            entity.Knowledge = model.Knowledge + model.Proficiency + (model.Intelligence * 3);
            entity.Bravery = model.Bravery + model.Proficiency + (model.Instinct * 3);
            entity.Pilotry = model.Pilotry + model.Proficiency + (model.Instinct * 3);
            entity.Insight = model.Insight + model.Proficiency + (model.Instinct * 3);
            entity.Perception = model.Perception + model.Proficiency + (model.Instinct * 3);
            entity.Survival = model.Survival + model.Proficiency + (model.Instinct * 3);
            entity.Faith = model.Faith + model.Proficiency + (model.Charisma * 3);
            entity.Deception = model.Deception + model.Proficiency + (model.Charisma * 3);
            entity.Diplomacy = model.Diplomacy + model.Proficiency + (model.Charisma * 3);
            entity.Intimidation = model.Intimidation + model.Proficiency + (model.Charisma * 3);
            entity.Performance = model.Performance + model.Proficiency + (model.Charisma * 3);
            entity.Seduction = model.Seduction + model.Proficiency + (model.Charisma * 3);

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

            if (model.ProwessType == "Strength")
            {
                entity.BaseProwess = 10 + (model.Strength * 2);
            }
            else if (model.ProwessType == "Agility")
            {
                entity.BaseProwess = 10 + (model.Agility * 2);
            }
            else
            {
                entity.BaseProwess = 10;
            }
            if (model.MagicType == "Intelligence")
            {
                entity.Magic = 10 + (model.Intelligence * 2);
            }
            else if (model.MagicType == "Charisma")
            {
                entity.Magic = 10 + (model.Charisma * 2);
            }
            else if (model.MagicType == "Instinct")
            {
                entity.Magic = 10 + (model.Instinct * 2);
            }
            else
            {
                entity.Magic = 0;
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
