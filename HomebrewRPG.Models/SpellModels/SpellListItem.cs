using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.SpellModels
{
    public class SpellListItem
    {
        public int SpellId { get; set; }
        [Display(Name ="Name")]
        public string SpellName { get; set; }
        [Display(Name = "Spell Type")]
        public string SpellType { get; set; }
    }
}
