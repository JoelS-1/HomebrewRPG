using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models
{
    public class CharacterCreate
    {
        [Required]
        public int CharacterId { get; set; }
        [Required]
        public string CharacterName { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public int CharacterLevel { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Allignment { get; set; }

        [Required]
        public int Health { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Agility { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Charisma { get; set; }
    }
}
