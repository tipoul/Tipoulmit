using Microsoft.EntityFrameworkCore;
using Tipoul.Console.WebApi.Data;
using Tipoul.Console.WebApi.Entity;
using Tipoul.Console.WebApi.Infrastructure;

namespace Tipoul.Console.WebApi.Services
{
    public class ResponseRepo: IResponseRepo
    {
        private ConsoleContext _context;
        public ResponseRepo(ConsoleContext context)
        {
            _context = context;
        }
        public Response GetById(int id)
        {
            var response = _context.Response.Where(x => x.Id == id).FirstOrDefault();
            return response;
        }
        public OperationResult Insert(Response response)
        {
            var res = _context.Response.Add(response);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();
        }
        public OperationResult Update(Response response)
        {

            var res = _context.Response.Update(response);
            if (res.State == EntityState.Modified)
                return OperationResult.Success();
            else
                return OperationResult.Error();
        }
    }
}
