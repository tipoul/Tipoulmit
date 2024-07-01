using Tipoul.Framework.DataAccessLayer;
using Tipoul.Wallet.WebApi.Models;

namespace Tipoul.Wallet.WebApi.Infrastructure
{
    public interface IBankAccountRepo
    {
        List<BankAccount> GetBankAccounts(TipoulFrameworkDbContext _tipoulframeworkdbcontext,int userid);
        string Insert(TipoulFrameworkDbContext _tipoulframeworkdbcontext, CartAccount cartaccount);
    }
}
