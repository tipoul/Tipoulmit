using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface IUsersRepo
    {
        Users GetById(long id);
        Users GetByNationalcode(string Nationalcode);
    }
}
