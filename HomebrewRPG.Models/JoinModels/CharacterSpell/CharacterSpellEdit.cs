using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterSpell
{
    public class CharacterSpellEdit
    {
        public int CharacterSpellId { get; set; }
        public int SpellId { get; set; }
        public int CharacterId { get; set; }
    }
}
