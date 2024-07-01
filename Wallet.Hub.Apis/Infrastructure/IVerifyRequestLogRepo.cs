using Wallet.Hub.Apis.Entity;

namespace Wallet.Hub.Apis.Infrastructure
{
    public interface IVerifyRequestLogRepo
    {
        void Insert(VerifyRequestLog verifyrequestlog);
    }
}
