using HomebrewRPG.Data;
using HomebrewRPG.Models.CharacterItemModels;
using HomebrewRPG.Models.CharacterWeaponModels;
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
        public List<CharacterItemDetail> Items { get; set; } = new List<CharacterItemDetail>();
        public List<CharacterWeaponDetail> Weapons { get; set; } = new List<CharacterWeaponDetail>();
        //public List<CharacterWardrobeItemDetail> WardrobeItems { get; set; } = new List<CharacterWardrobeItemDetail>();
        public CharacterDetail CharacterDetail { get; set; }

    }
}
