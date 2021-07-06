using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class CharacterItem
    {
        [Key]
        public int CharacterItemId { get; set; }


        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        [Required]
        public int Quantity { get; set; }
        public int RemainingUses { get; set; }

        public Guid OwnerId { get; set; }
    }
}
