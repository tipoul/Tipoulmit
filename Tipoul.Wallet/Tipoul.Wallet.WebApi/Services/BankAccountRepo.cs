using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Wallet.WebApi.Data;
using Tipoul.Wallet.WebApi.Infrastructure;
using Tipoul.Wallet.WebApi.Models;
using Tipoul.Wallet.WebApi.Utilities;

namespace Tipoul.Wallet.WebApi.Services
{
    public class BankAccountRepo : IBankAccountRepo
    {
        private WalletWebApiContext _context;
        public BankAccountRepo(WalletWebApiContext context)
        {
            _context = context;
        }

        public List<BankAccount> GetBankAccounts(TipoulFrameworkDbContext _tipoulframeworkdbcontext, int userid)
        {
            try
            {
                
                var entry = _tipoulframeworkdbcontext.BankAccounts.Where(x => x.WalletUserId == userid && x.IsActive == true).ToList();
                if (entry.Count > 0)
                {
                   return entry.AsEnumerable().Select((entry, index) => new BankAccount()
                    {
                        Iban = entry.Iban,
                        BankId = entry.BankId,
                        FullName = entry.FullName,
                        NationalCode = entry.NationalCode,
                        Id = entry.Id,
                        Images= Utilitys.GetBankImages(_tipoulframeworkdbcontext,entry.BankId),
                        CartNo=entry.CartNo

                   }).ToList();
                }
                else
                    return null;
                }
            catch (Exception ex)
            {
                return null;
            }

        }
        
        public string Insert(TipoulFrameworkDbContext _tipoulframeworkdbcontext, CartAccount cartaccount)
        {
            Framework.StorageModels.BankAccount Objs = new Framework.StorageModels.BankAccount();

            Objs.UserId = 1;
            Objs.WalletUserId = cartaccount.WalletUserId;
            Objs.BankId = 0;
            Objs.Iban = cartaccount.Iban;
            Objs.IsActive = true;
            Objs.FullName = cartaccount.FullName;
            Objs.Trashed = false;
            Objs.NationalCode = cartaccount.NationalCode;
            Objs.CartNo = cartaccount.CartNo;

            try
            {
                var ObjsBank = _tipoulframeworkdbcontext.Banks.Where(r => r.Code == cartaccount.BankCode).FirstOrDefault();
                if (ObjsBank != null)
                {
                    Objs.BankId = ObjsBank.Id;

                    var res = _tipoulframeworkdbcontext.BankAccounts.Add(Objs);

                    if (res.State == EntityState.Added)
                    {
                        _tipoulframeworkdbcontext.BankAccounts.AddAsync(Objs);
                        _tipoulframeworkdbcontext.SaveChangesAsync();

                        return "Success";
                    }

                    else return "Error";
                }
                else return "Error";
            }
            catch(Exception ex) {
                return "";
            }

        }

    }
}
