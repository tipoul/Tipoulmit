using Microsoft.EntityFrameworkCore;
using Tipoul.Console.WebApi.Data;
using Tipoul.Console.WebApi.Entity;
using Tipoul.Console.WebApi.Infrastructure;

namespace Tipoul.Console.WebApi.Services
{
    public class RequestRepo: IRequestRepo
    {
        private ConsoleContext _context;
        public RequestRepo(ConsoleContext context)
        {
            _context = context;
        }
        public Request GetById(int id)
        {
            var request = _context.Request.Where(x => x.Id == id).FirstOrDefault();
            return request;
        }
        public OperationResult Insert(Request request)
        {
            var res = _context.Request.Add(request);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();
        }
        public OperationResult Update(Request request)
        {

            var res = _context.Request.Update(request);
            if (res.State == EntityState.Modified)
                return OperationResult.Success();
            else
                return OperationResult.Error();
        }
        public Request GetByFactorNo(long FactorNumber)
        {
            var request = _context.Request.Where(x => x.FactorNumber == FactorNumber).FirstOrDefault();
            return request;
        }
        public Request GetByGTTN(string GTTN)
        {
            var request = _context.Request.Where(x => x.GTTN == GTTN).FirstOrDefault();
            return request;
        }
        
    }
}
