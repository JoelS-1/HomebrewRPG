﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class Heroic
    {
        [Key]
        public int HeroicId { get; set; }
        [Required]
        public string HeroicName { get; set; }
        [Required]
        [Display(Name = "PersonalHeroic")]
        public bool IsPersonalHeroic { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Required Level")]
        public int RequiredLevel { get; set; }
        [Required]
        [Display(Name = "Required Heroic")]
        public string RequiredHeroic { get; set; }
        [Required]
        [Display(Name = "Required Agility")]
        public int RequiredAgility { get; set; }
        [Required]
        [Display(Name = "Required Strength")]
        public int RequiredStrength { get; set; }
        [Required]
        [Display(Name = "Required Instinct")]
        public int RequiredInstinct { get; set; }
        [Required]
        [Display(Name = "Required Intelligence")]
        public int RequiredIntelligence { get; set; }
        [Required]
        [Display(Name = "Required Charisma")]
        public int RequiredCharisma { get; set; }
        [Required]
        [Display(Name = "Required Health")]
        public int RequiredHealth { get; set; }
        public Guid OwnerId { get; set; }
    }
}
