using Azure.Core;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;
using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;
using Tipoul.Wallet.Switch.Models;
using Tipoul.Wallet.Switch.Services;

namespace Tipoul.Wallet.Switch.Utilities
{
    public static class Utility
    {

        public static long GetWallet(SwitchWalletContext _context, int WalletNo)
        {
            WalletsRepo wre = new WalletsRepo(_context);
            var resultres = wre.GetByWalletNo(WalletNo);
            if (resultres != null)
                return resultres.Id;
            else
                return 0;
        }
        public static Users GetSourceUser(SwitchWalletContext _context, long WalletNo)
        {
            var resultres = _context.Wallets.FirstOrDefault(r => r.WalletNo == WalletNo);
            if (resultres != null)
            {
                long UserId = resultres.UserId.Value;
                var Objsuser = _context.Users.FirstOrDefault(r => r.Id == UserId);
                if (Objsuser != null)
                {
                    Users _users = new Users();
                    _users.Id = Objsuser.Id;
                    _users.Name = Objsuser.Name;
                    _users.Lastname = Objsuser.Lastname;
                    _users.Mobile = Objsuser.Mobile;
                    _users.Nationalcode = Objsuser.Nationalcode;

                    return _users;
                }
                else
                    return null;
            }
            else
                return null;
        }
       
      
    }
}
