using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class CharacterSpell
    {
        [Key]
        public int CharacterSpellId { get; set; }


        [ForeignKey(nameof(Spell))]
        public int SpellId { get; set; }
        public virtual Spell Spell { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public Guid OwnerId { get; set; }
    }
}
