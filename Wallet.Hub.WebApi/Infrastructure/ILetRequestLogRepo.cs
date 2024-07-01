

using Wallet.Hub.WebApi.Entity;

namespace Wallet.Hub.WebApi.Infrastructure
{
    public interface ILetRequestLogRepo
    {
        OperationResult Insert(LetRequestLog letrequestlog);
    }
}
