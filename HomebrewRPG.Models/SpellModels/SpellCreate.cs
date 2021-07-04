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
        public string SpellName { get; set; }
        [Required]
        public string SpellDescription { get; set; }
        [Required]
        public string SpellEffect { get; set; }
        [Required]
        public string SpellType { get; set; }
        [Required]
        public int Range { get; set; }
        [Required]
        public int SpellDC { get; set; }
    }
}
