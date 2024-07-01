using Wallet.Hub.Apis.Entity;

namespace Wallet.Hub.Apis.Infrastructure
{
    public interface IVerifyResponseLogRepo
    {
        void Insert(VerifyResponseLog verifyresponselog);
    }
}
