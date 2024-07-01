

using Wallet.Hub.WebApi.Entity;

namespace Wallet.Hub.WebApi.Infrastructure
{
    public interface IGetTokenResponseRepo
    {
        OperationResult Insert(GetTokenResponse gettokenresponse);
        GetTokenResponse GetByToken(string token);
    }
}
