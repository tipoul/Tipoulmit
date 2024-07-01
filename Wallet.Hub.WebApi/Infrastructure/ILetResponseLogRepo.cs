

using Wallet.Hub.WebApi.Entity;

namespace Wallet.Hub.WebApi.Infrastructure
{
    public interface ILetResponseLogRepo
    {
        void Insert(LetResponseLog letresponselog);
    }
}
