using Tipoul.Console.WebApi.Entity;

namespace Tipoul.Console.WebApi.Infrastructure
{
    public interface IResponseRepo
    {
        Response GetById(int id);
        OperationResult Insert(Response response);
        OperationResult Update(Response response);
    }
}
