using Tipoul.Console.WebApi.Entity;

namespace Tipoul.Console.WebApi.Infrastructure
{
    public interface IRequestRepo
    {
        Request GetById(int id);
        Request GetByGTTN(string GTTN);
        Request GetByFactorNo(long FactorNumber);
        OperationResult Insert(Request request);
        OperationResult Update(Request request);
    }

}
