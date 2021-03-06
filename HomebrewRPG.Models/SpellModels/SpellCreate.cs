using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.SpellModels
{
    public class SpellCreate
    {
        [Required]
        [Display(Name ="Name")]
        public string SpellName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string SpellDescription { get; set; }
        [Required]
        [Display(Name = "Effect")]
        public string SpellEffect { get; set; }
        [Required]
        [Display(Name = "Spell Type")]
        public string SpellType { get; set; }
        [Required]
        public int Range { get; set; }
        [Required]
        [Display(Name = "Spell DC")]
        public int SpellDC { get; set; }
    }
}
