using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterWeaponModels
{
    public class CharacterWeaponEdit
    {
        public int CharacterWeaponId { get; set; }
        public int WeaponId { get; set; }
        public int CharacterId { get; set; }
        public bool IsEquipped { get; set; }
    }
}
