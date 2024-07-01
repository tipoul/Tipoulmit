using Tipoul.Console.WebApi.Entity;

namespace Tipoul.Console.WebApi.Infrastructure
{
    public interface IVerifyRepo
    {
        Verify GetById(int id);
        OperationResult Insert(Verify verify);
        OperationResult Update(Verify verify);
    }
}
