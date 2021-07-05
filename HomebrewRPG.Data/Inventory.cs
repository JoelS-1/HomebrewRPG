using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public int InventoryItem { get; set; }
        public int InventoryWardrobe { get; set; }
        public int InventoryWeapon { get; set; }

        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }
        public Guid OwnerId { get; set; }
    }
}
