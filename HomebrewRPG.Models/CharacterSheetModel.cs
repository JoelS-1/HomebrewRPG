using HomebrewRPG.Data;
using HomebrewRPG.Models.CharacterItemModels;
using HomebrewRPG.Models.CharacterSpell;
using HomebrewRPG.Models.CharacterWardrobeModels;
using HomebrewRPG.Models.CharacterWeaponModels;
using HomebrewRPG.Models.ItemModels;
using HomebrewRPG.Models.WardrobeItemModels;
using HomebrewRPG.Models.WeaponModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models
{
    public class CharacterSheetModel
    {
        public List<CharacterItemDetail> Items { get; set; } = new List<CharacterItemDetail>();
        public List<CharacterWeaponDetail> Weapons { get; set; } = new List<CharacterWeaponDetail>();
        public List<CharacterWardrobeDetail> WardrobeItems { get; set; } = new List<CharacterWardrobeDetail>();
        public List<CharacterSpellDetail> Spells { get; set; } = new List<CharacterSpellDetail>();
        public CharacterEdit CharacterDetail { get; set; }

        public CharacterDetail BonusesDetail { get; set; }

        [Display(Name="Health")]
        public int UntrainedHealth { get; set; }
        [Display(Name = "Strength")]
        public int UntrainedStrength { get; set; }
        [Display(Name = "Instinct")]
        public int UntrainedInstinct { get; set; }
        [Display(Name = "Agility")]
        public int UntrainedAgility { get; set; }
        [Display(Name = "Intelligence")]
        public int UntrainedIntelligence { get; set; }
        [Display(Name = "Charisma")]
        public int UntrainedCharisma { get; set; }

        [Display(Name = "Armor")]
        public int PhysicalResistance { get; set; }
        [Display(Name = "Magic Resist")]
        public int MagicResistance { get; set; }

    }
}
