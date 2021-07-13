using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterSpell
{
    public class CharacterSpellCreate
    {
        public int CharacterSpellId { get; set; }


        [Required]
        public int SpellId { get; set; }
        [Required]
        public int CharacterId { get; set; }
    }
}
