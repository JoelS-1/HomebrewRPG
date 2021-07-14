using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class CharacterWeapon
    {
        [Key]
        public int CharacterWeaponId { get; set; }


        [ForeignKey(nameof(Weapon))]
        public int WeaponId { get; set; }
        public virtual Weapon Weapon { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public bool IsEquipped { get; set; }

        public Guid OwnerId { get; set; }
    }
}
