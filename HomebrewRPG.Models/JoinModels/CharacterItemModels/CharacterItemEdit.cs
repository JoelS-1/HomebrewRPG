using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterItemModels
{
    public class CharacterItemEdit
    {
        public int CharacterItemId { get; set; }
        public int ItemId { get; set; }
        public int CharacterId { get; set; }
        public int Quantity { get; set; }
    }
}
