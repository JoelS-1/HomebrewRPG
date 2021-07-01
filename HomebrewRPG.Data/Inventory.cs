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
        [Required]
        public string InventoryName { get; set; }

        [ForeignKey(nameof(Weapon))]
        public int WeaponId { get; set; }
        public virtual Weapon Weapon { get; set; }
        public List<Weapon> Weapons { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public List<Item> Items { get; set; }


        [ForeignKey(nameof(WardrobeItem))]
        public int WardrobeItemId { get; set; }
        public virtual WardrobeItem WardrobeItem { get; set; }
        public List<WardrobeItem> Wardrobe { get; set; }

        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }
    }
}
