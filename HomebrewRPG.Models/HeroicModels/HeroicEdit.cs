using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.HeroicModels
{
    public class HeroicEdit
    {
        public int HeroicId { get; set; }
        [Display(Name = "Name")]
        public string HeroicName { get; set; }
        [Display(Name = "Personal Heroic")]
        public bool IsPersonalHeroic { get; set; }
        public string Description { get; set; }

        [Display(Name = "Required Level")]
        public int RequiredLevel { get; set; }
        [Display(Name = "Required Heroic")]
        public string RequiredHeroic { get; set; }
        [Display(Name = "Required Agility")]
        public int RequiredAgility { get; set; }
        [Display(Name = "Required Strength")]
        public int RequiredStrength { get; set; }
        [Display(Name = "Required Instinct")]
        public int RequiredInstinct { get; set; }
        [Display(Name = "Required Intelligence")]
        public int RequiredIntelligence { get; set; }
        [Display(Name = "Required Charisma")]
        public int RequiredCharisma { get; set; }
        [Display(Name = "Required Health")]
        public int RequiredHealth { get; set; }
    }
}
