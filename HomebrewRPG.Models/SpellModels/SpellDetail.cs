using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.SpellModels
{
    public class SpellDetail
    {
        public int SpellId { get; set; }
        public string SpellName { get; set; }
        public string SpellDescription { get; set; }
        public string SpellEffect { get; set; }
        public string SpellType { get; set; }
        public int Range { get; set; }
        public int SpellDC { get; set; }
    }
}
