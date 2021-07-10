using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.WardrobeItemModels
{
    public class WardrobeItemCreate
    {
        [Required]
        public string ArmorName { get; set; }
        [Required]
        public string ArmorType { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int HealthRequired { get; set; }
        [Required]
        public int StrengthRequired { get; set; }
        [Required]
        public int AgilityRequired { get; set; }
        [Required]
        public int MagicRequired { get; set; }
        [Required]
        public string Special { get; set; }

        [Required]
        public int PhysicalResistance { get; set; }
        [Required]
        public int MagicalResistance { get; set; }
    }
}
