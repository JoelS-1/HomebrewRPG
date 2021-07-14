using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterWardrobeModels
{
    public class CharacterWardrobeEdit
    {
        public int CharacterWardrobeId { get; set; }

        public int CharacterId { get; set; }
        public int WardrobeItemId { get; set; }
        public bool IsEquipped { get; set; }
    }
}
