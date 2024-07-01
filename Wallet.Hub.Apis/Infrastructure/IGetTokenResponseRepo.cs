using Wallet.Hub.Apis.Entity;

namespace Wallet.Hub.Apis.Infrastructure
{
    public interface IGetTokenResponseRepo
    {
        void Insert(GetTokenResponse gettokenresponse);
    }
}
