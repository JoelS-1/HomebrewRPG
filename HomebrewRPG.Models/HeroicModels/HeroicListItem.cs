using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.HeroicModels
{
    public class HeroicListItem
    {
        public int HeroicId { get; set; }
        public string HeroicName { get; set; }
        public bool IsPersonalHeroic { get; set; }
        public string Description { get; set; }
    }
}
