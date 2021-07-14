﻿using HomebrewRPG.Data;
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
                                Gold = e.Gold,
                                Silver = e.Gold,
                                Copper = e.Copper
                            }
                    );
            return query.ToArray();
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
                    Gold = entity.Gold,
                    Silver = entity.Silver,
                    Copper = entity.Copper
                };
        }

        public bool UpdateWallet (WalletEdit model)
        {
            var entity =
                _ctx
                    .Wallets
                    .Single(e => e.WalletId == model.WalletId && e.OwnerId == _userId);
            entity.WalletId = model.WalletId;
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