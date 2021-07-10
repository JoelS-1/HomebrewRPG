using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.WeaponModels
{
    public class WeaponEdit
    {
        public int WeaponId { get; set; }
        public string WeaponName { get; set; }
        public string Description { get; set; }
        public string WeaponType { get; set; }

        public string DamageDice { get; set; }
        public int DamageModifier { get; set; }
        public int ProwessBonus { get; set; }
        public int Range { get; set; }
        public string CriticalRange { get; set; }
        public string Special { get; set; }

        public int Parrying { get; set; }
        public int PhysicalBlocking { get; set; }
        public int MagicalBlocking { get; set; }
    }
}
