using Wallet.Hub.Apis.Entity;

namespace Wallet.Hub.Apis.Infrastructure
{
    public interface IGetTokenRequestRepo
    {
        OperationResult Insert(GetTokenRequest gettokenrequest);
    }
}
