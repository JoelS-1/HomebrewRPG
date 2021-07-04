using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models
{
    public class HeroicDetail
    {
        public int HeroicId { get; set; }
        public string HeroicName { get; set; }
        public bool IsPersonalHeroic { get; set; }
        public string Description { get; set; }

        public int RequiredLevel { get; set; }
        public string RequiredHeroic { get; set; }
        public int RequiredAgility { get; set; }
        public int RequiredStrength { get; set; }
        public int RequiredInstinct { get; set; }
        public int RequiredIntelligence { get; set; }
        public int RequiredCharisma { get; set; }
        public int RequiredHealth { get; set; }
    }
}
