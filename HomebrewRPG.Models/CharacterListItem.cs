using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models
{
    public class CharacterListItem
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string Race { get; set; }
        [Display(Name = "Level")]
        public int CharacterLevel { get; set; }
    }
}
