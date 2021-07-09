using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterItemModels
{
    public class CharacterItemDetail
    {
        public int ItemId { get; set; }
        public int CharacterId { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}
