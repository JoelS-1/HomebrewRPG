using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.HeroicModels
{
    public class HeroicListItem
    {
        public int HeroicId { get; set; }
        [Display(Name ="Name")]
        public string HeroicName { get; set; }
        [Display(Name = "Personal Heroic")]
        public bool IsPersonalHeroic { get; set; }
        public string Description { get; set; }
    }
}
