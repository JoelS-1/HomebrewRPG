using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterItemModels
{
    public class CharacterItemDetail
    {
        public int CharacterItemId { get; set; }
        public int ItemId { get; set; }
        public int CharacterId { get; set; }
        public int Quantity { get; set; }
        [Display(Name="Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }
    }
}
