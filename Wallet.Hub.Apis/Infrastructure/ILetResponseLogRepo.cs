using Wallet.Hub.Apis.Entity;

namespace Wallet.Hub.Apis.Infrastructure
{
    public interface ILetResponseLogRepo
    {
        void Insert(LetResponseLog letresponselog);
    }
}
