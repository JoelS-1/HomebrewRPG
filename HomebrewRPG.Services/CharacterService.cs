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
                    Allignment = model.Gender,
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
    }
}
