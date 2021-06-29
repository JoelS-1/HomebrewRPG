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
                    Agility = model.Agility,
                    Intelligence = model.Intelligence,
                    Charisma = model.Charisma
                };

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
                    Agility = entity.Agility,
                    Intelligence = entity.Intelligence,
                    Charisma = entity.Charisma
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
            entity.Agility = model.Agility;
            entity.Intelligence = model.Intelligence;
            entity.Charisma = model.Charisma;

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
