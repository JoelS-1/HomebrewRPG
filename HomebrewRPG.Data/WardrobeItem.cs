using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class WardrobeItem
    {
        [Key]
        public int WardobeItemId { get; set; }
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

        public int PhysicalBlocking { get; set; }
        public int MagicalBlocking { get; set; }

        [Required]
        public int PhysicalResistance { get; set; }
        [Required]
        public int MagicalResistance { get; set; }

        public Dictionary<string, int> StatBonuses { get; set; }
        public Guid OwnerId { get; set; }
    }
}
