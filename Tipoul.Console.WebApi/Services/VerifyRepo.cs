using Microsoft.EntityFrameworkCore;
using Tipoul.Console.WebApi.Data;
using Tipoul.Console.WebApi.Entity;
using Tipoul.Console.WebApi.Infrastructure;

namespace Tipoul.Console.WebApi.Services
{
    public class VerifyRepo: IVerifyRepo
    {
        private ConsoleContext _context;
        public VerifyRepo(ConsoleContext context)
        {
            _context = context;
        }

        public Verify GetById(int id)
        {
            var verify = _context.Verify.Where(x => x.Id == id).FirstOrDefault();
            return verify;
        }
        public OperationResult Insert(Verify verify)
        {
            var res = _context.Verify.Add(verify);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();
        }
        public OperationResult Update(Verify verify)
        {

            var res = _context.Verify.Update(verify);
            if (res.State == EntityState.Modified)
                return OperationResult.Success();
            else
                return OperationResult.Error();
        }
    }
}
