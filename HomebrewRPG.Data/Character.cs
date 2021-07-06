using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public string CharacterName { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        [Range(1, 20)]
        public int CharacterLevel { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Allignment { get; set; }

        [Required]
        public int Health { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Instinct { get; set; }
        [Required]
        public int Agility { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Charisma { get; set; }

        [Required]
        public string MagicType { get; set; }
        [Required]
        public string ProwessType { get; set; }
        public int Proficiency { get; set; }

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

        public int DamageResistance { get; set; }
        public int MagicResistance { get; set; }

        public Guid OwnerId { get; set; }
    }
}
