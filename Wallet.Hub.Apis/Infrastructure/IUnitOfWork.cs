namespace Wallet.Hub.Apis.Infrastructure
{
    public interface IUnitOfWork
    {
        IGetTokenRequestRepo GetTokenRequestRepo { get; }
        IGetTokenResponseRepo GetTokenResponseRepo { get; }
        ILetRequestLogRepo LetRequestLogRepo { get; }
        ILetResponseLogRepo LetResponseLogRepo { get; }
        IVerifyRequestLogRepo VerifyRequestLogRepo { get; }
        IVerifyResponseLogRepo VerifyResponseLogRepo { get; }
       
        void Save();
    }
}
