using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.WardrobeItemModels
{
    public class WardrobeListItem
    {
        public int WardobeItemId { get; set; }
        [Display(Name = "Name")]
        public string ArmorName { get; set; }
        [Display(Name ="Armor Type")]
        public string ArmorType { get; set; }
        public string Description { get; set; }
    }
}
