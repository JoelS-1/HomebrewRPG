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
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        public int Uses { get; set; }
    }
}
