using HomebrewRPG.Data;
using HomebrewRPG.Models.WalletModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Services
{
    public class WalletService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public WalletService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWallet(WalletCreate model)
        {
            var entity =
                new Wallet()
                {
                    OwnerId = _userId,
                    CharacterId = model.CharacterId,
                    Gold = model.Gold,
                    Silver = model.Silver,
                    Copper = model.Copper,
                };
            _ctx.Wallets.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<WalletListItem> GetWallets()
        {
            var query =
                _ctx
                    .Wallets
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new WalletListItem
                            {
                                WalletId = e.WalletId,
                                CharacterId = e.CharacterId,
                                Gold = e.Gold,
                                Silver = e.Gold,
                                Copper = e.Copper
                            }
                    );
            return query.ToArray();
        }
        public WalletEdit GetWalletByCharacterId(int id)
        {
            var entity =
                _ctx
                    .Wallets
                    .SingleOrDefault(e => e.CharacterId == id && e.OwnerId == _userId);
            if (entity == default)
            {
                var newWallet = new WalletCreate()
                {
                    CharacterId = id,
                    Gold = 0,
                    Silver = 0,
                    Copper = 0
                };
                CreateWallet(newWallet);
                var final = GetWalletByCharacterId(id);
                return final;
            }
            else
            {
                return
                    new WalletEdit
                    {
                        WalletId = entity.WalletId,
                        CharacterId = entity.CharacterId,
                        Gold = entity.Gold,
                        Silver = entity.Silver,
                        Copper = entity.Copper
                    };
            }
        }

        public WalletDetail GetWalletById(int id)
        {
            var entity =
                _ctx
                    .Wallets
                    .Single(e => e.WalletId == id && e.OwnerId == _userId);
            return
                new WalletDetail
                {
                    WalletId = entity.WalletId,
                    CharacterId = entity.CharacterId,
                    Gold = entity.Gold,
                    Silver = entity.Silver,
                    Copper = entity.Copper
                };
        }

        public bool UpdateWallet(WalletEdit model)
        {
            var entity =
                _ctx
                    .Wallets
                    .Single(e => e.WalletId == model.WalletId && e.OwnerId == _userId);
            entity.WalletId = model.WalletId;
            entity.CharacterId = model.CharacterId;
            entity.Gold = model.Gold;
            entity.Silver = model.Silver;
            entity.Copper = model.Copper;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteWallet(int itemId)
        {
            var entity =
                _ctx
                    .Wallets
                    .Single(e => e.WalletId == itemId && e.OwnerId == _userId);
            _ctx.Wallets.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}
