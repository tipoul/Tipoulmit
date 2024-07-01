using Wallet.Hub.WebApi.Entity;

namespace Wallet.Hub.WebApi.Infrastructure
{
    public interface IGetTokenRequestRepo
    {
        OperationResult Insert(GetTokenRequest gettokenrequest);
        GetTokenResponse GetByToken(string token);
        GetTokenRequest GetRequest(long id);
        
    }
}

