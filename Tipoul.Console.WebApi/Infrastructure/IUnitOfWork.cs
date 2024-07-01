namespace Tipoul.Console.WebApi.Infrastructure
{
    public interface IUnitOfWork
    {
        IRequestRepo RequestRepo { get; }
        IResponseRepo ResponseRepo { get; }
        IVerifyRepo VerifyRepo { get; }
        void Save();
    }
}
