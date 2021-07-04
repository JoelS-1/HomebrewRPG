using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.HeroicModels
{
    public class HeroicCreate
    {
        [Required]
        public string HeroicName { get; set; }
        [Required]
        public bool IsPersonalHeroic { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int RequiredLevel { get; set; }
        [Required]
        public string RequiredHeroic { get; set; }
        [Required]
        public int RequiredAgility { get; set; }
        [Required]
        public int RequiredStrength { get; set; }
        [Required]
        public int RequiredInstinct { get; set; }
        [Required]
        public int RequiredIntelligence { get; set; }
        [Required]
        public int RequiredCharisma { get; set; }
        [Required]
        public int RequiredHealth { get; set; }
    }
}
