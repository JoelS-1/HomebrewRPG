using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        public int Uses { get; set; }

        public Dictionary<string, int> StatBonuses { get; set; }
        public Guid OwnerId { get; set; }
    }
}
