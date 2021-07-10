using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.WeaponModels
{
    public class WeaponCreate
    {
        [Required]
        public string WeaponName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string WeaponType { get; set; }

        [Required]
        public string DamageDice { get; set; }
        [Required]
        public int Range { get; set; }
        [Required]
        public string CriticalRange { get; set; }
        [Required]
        public string Special { get; set; }

        public int Parrying { get; set; }
        public int PhysicalBlocking { get; set; }
        public int MagicalBlocking { get; set; }

        [Required]
        public int DamageModifier { get; set; }
        [Required]
        public int ProwessBonus { get; set; }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Instinct { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        public int HitPoints { get; set; }
        public int Sanity { get; set; }
        public int Dodge { get; set; }
        public int Reaction { get; set; }
        public int BaseProwess { get; set; }
        public int Magic { get; set; }
        public int Fate { get; set; }
        public int Speed { get; set; }

        public int Endurance { get; set; }
        public int Constitution { get; set; }
        public int Athletics { get; set; }
        public int Tenacity { get; set; }
        public int Acrobatics { get; set; }
        public int SleightOfHand { get; set; }
        public int Sneak { get; set; }
        public int Willpower { get; set; }
        public int Investigation { get; set; }
        public int Knowledge { get; set; }
        public int Bravery { get; set; }
        public int Pilotry { get; set; }
        public int Insight { get; set; }
        public int Perception { get; set; }
        public int Survival { get; set; }
        public int Faith { get; set; }
        public int Deception { get; set; }
        public int Diplomacy { get; set; }
        public int Intimidation { get; set; }
        public int Performance { get; set; }
        public int Seduction { get; set; }

    }
}
