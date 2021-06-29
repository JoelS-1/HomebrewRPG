using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models
{
    public class CharacterEdit
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string Race { get; set; }
        public int CharacterLevel { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Allignment { get; set; }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
    }
}
