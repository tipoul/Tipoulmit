using Tipoul.Console.WebApi.Data;
using Tipoul.Console.WebApi.Infrastructure;

namespace Tipoul.Console.WebApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ConsoleContext _context;
        private IRequestRepo _requestRepo;
        private IResponseRepo _responseRepo;
        private IVerifyRepo _verifyRepo;
        public UnitOfWork(ConsoleContext context)
        {
            _context = context;
        }
        public IRequestRepo RequestRepo
        {
            get
            {
                return _requestRepo = _requestRepo ?? new RequestRepo(_context);
            }
        }
        public IResponseRepo ResponseRepo
        {
            get
            {
                return _responseRepo = _responseRepo ?? new ResponseRepo(_context);
            }
        }
        public IVerifyRepo VerifyRepo
        {
            get
            {
                return _verifyRepo = _verifyRepo ?? new VerifyRepo(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
