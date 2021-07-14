using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.WalletModels
{
    public class WalletDetail
    {
        public int WalletId { get; set; }
        public int CharacterId { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }
    }
}
