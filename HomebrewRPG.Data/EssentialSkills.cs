using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class EssentialSkills
    {
        public int EssentialSkillsId { get; set; }
        public int HitPoints { get; set; }
        public int Sanity { get; set; }
        public int Dodge { get; set; }
        public int Reaction { get; set; }
        public int BaseProwess { get; set; }
        public int Magic { get; set; }
        public int Fate { get; set; }
        public int Speed { get; set; }


        public int DamageResistance { get; set; }
        public int MagicResistance { get; set; }
    }
}
