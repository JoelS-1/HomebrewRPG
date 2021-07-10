using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterWeaponModels
{
    public class CharacterWeaponDetail
    {
        public int CharacterWeaponId { get; set; }
        public int WeaponId { get; set; }
        public int CharacterId { get; set; }
        public bool IsEquipped { get; set; }


        public string WeaponName { get; set; }
        public string Description { get; set; }
        public string WeaponType { get; set; }

        public string DamageDice { get; set; }
        public int DamageModifier { get; set; }
        public int ProwessBonus { get; set; }
        public int Range { get; set; }
        public string CriticalRange { get; set; }
        public string Special { get; set; }
    }
}
