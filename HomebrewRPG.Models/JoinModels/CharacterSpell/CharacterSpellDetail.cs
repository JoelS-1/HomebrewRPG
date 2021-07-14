using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.CharacterSpell
{
    public class CharacterSpellDetail
    {
        public int CharacterSpellId { get; set; }
        public int SpellId { get; set; }
        public int CharacterId { get; set; }

        [Display(Name = "Name")]
        public string SpellName { get; set; }
        [Display(Name = "Description")]
        public string SpellDescription { get; set; }
        [Display(Name = "Effect")]
        public string SpellEffect { get; set; }
        [Display(Name = "Spell Type")]
        public string SpellType { get; set; } //fire, water, instinct, charisma
        public int Range { get; set; }
        [Display(Name = "DC")]
        public int SpellDC { get; set; }
    }
}
