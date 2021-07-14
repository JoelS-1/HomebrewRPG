using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class CharacterWardrobe
    {
        [Key]
        public int CharacterWardobeId { get; set; }


        [ForeignKey(nameof(WardrobeItem))]
        public int WardrobeItemId { get; set; }
        public virtual WardrobeItem WardrobeItem { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public bool IsEquipped { get; set; }

        public Guid OwnerId { get; set; }
    }
}
