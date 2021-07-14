using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.ItemModels
{
    public class ItemEdit
    {
        public int ItemId { get; set; }
        [Display(Name ="Name")]
        public string ItemName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Consumable")]
        public bool IsConsumable { get; set; }
    }
}
