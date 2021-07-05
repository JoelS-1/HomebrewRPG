using HomebrewRPG.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.InventoryModels
{
    public class InventoryCreate
    {
        [Required]
        public string InventoryName { get; set; }

        public int WeaponId { get; set; }

        public int ItemId { get; set; }

        public int HelmetId { get; set; }

        public int ChestId { get; set; }

        public int LegsId { get; set; }

        public int FeetId { get; set; }

        public int GlovesId { get; set; }

        public int CloakId { get; set; }

        public int AmuletId { get; set; }

        public int Ring1Id { get; set; }

        public int Ring2Id { get; set; }

        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }
    }
}
