using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterWardrobeModels
{
    public class CharacterWardrobeDetail
    {
        public int CharacterWardrobeId { get; set; }

        public int CharacterId { get; set; }
        public int WardrobeItemId { get; set; }
        public bool IsEquipped { get; set; }

        public string ArmorName { get; set; }
        public string ArmorType { get; set; }
        public string Description { get; set; }

        public int HealthRequired { get; set; }
        public int StrengthRequired { get; set; }
        public int AgilityRequired { get; set; }
        public int MagicRequired { get; set; }
        public string Special { get; set; }

        public int PhysicalBlocking { get; set; }
        public int MagicalBlocking { get; set; }

        public int PhysicalResistance { get; set; }
        public int MagicalResistance { get; set; }
    }
}
