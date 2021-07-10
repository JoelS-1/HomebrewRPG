using HomebrewRPG.Data;
using HomebrewRPG.Models.ItemModels;
using HomebrewRPG.Models.WardrobeItemModels;
using HomebrewRPG.Models.WeaponModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models
{
    public class CharacterSheetModel
    {
        public List<CharacterItem> items { get; set; }
        public List<WeaponDetail> weapons { get; set; }
        public List<WardrobeItemDetail> wardrobeItems { get; set; }
        public CharacterDetail characterDetail { get; set; }

    }
}
