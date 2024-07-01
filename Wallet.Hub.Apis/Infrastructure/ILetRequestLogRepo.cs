using Wallet.Hub.Apis.Entity;

namespace Wallet.Hub.Apis.Infrastructure
{
    public interface ILetRequestLogRepo
    {
        void Insert(LetRequestLog letrequestlog);
    }
}
