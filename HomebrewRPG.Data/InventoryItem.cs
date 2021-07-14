using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class InventoryItem
    {
        [Key]
        public int InventoryItemId { get; set; }

        public int InvenotryId { get; set; }
        public int ItemId { get; set; }

        //plan to for each through inventoryID to populate every item attached to the character inventory
    }
}
