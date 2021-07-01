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
        public int DamageModifier { get; set; }
        [Required]
        public int ProwessBonus { get; set; }
        [Required]
        public int Range { get; set; }
        [Required]
        public string CriticalRange { get; set; }
        [Required]
        public string Special { get; set; }

        public int Parrying { get; set; }
        public int PhysicalBlocking { get; set; }
        public int MagicalBlocking { get; set; }

        public Dictionary<string, int> StatBonuses { get; set; }
    }
}
