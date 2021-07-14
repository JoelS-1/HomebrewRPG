using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterItemModels
{
    public class CharacterItemCreate
    {
        public int ItemId { get; set; }
        public string CharacterId { get; set; }
        public string Quantity { get; set; }
    }
}
