

using Wallet.Hub.WebApi.Entity;

namespace Wallet.Hub.WebApi.Infrastructure
{
    public interface IVerifyResponseLogRepo
    {
        void Insert(VerifyResponseLog verifyresponselog);
    }
}
