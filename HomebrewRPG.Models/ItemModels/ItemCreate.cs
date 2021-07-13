using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.ItemModels
{
    public class ItemCreate
    {
        [Required]
        [Display(Name ="Name")]
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        public int Uses { get; set; }
        [Display(Name="Consumable?")]
        public bool IsConsumable { get; set; }
    }
}
