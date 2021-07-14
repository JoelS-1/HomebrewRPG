using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Data
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public Guid OwnerId { get; set; }
    }
}
