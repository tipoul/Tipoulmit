using Wallet.Hub.Apis.Data;
using Wallet.Hub.Apis.Infrastructure;

namespace Wallet.Hub.Apis.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;
        private IGetTokenRequestRepo _getTokenRequestRepo;
        private IGetTokenResponseRepo _getTokenResponseRepo;
        private ILetRequestLogRepo _letRequestLogRepo;
        private ILetResponseLogRepo _letResponseLogRepo;
        private IVerifyRequestLogRepo _verifyRequestLogRepo;
        private IVerifyResponseLogRepo _verifyResponseLogRepo;
        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public IGetTokenRequestRepo GetTokenRequestRepo
        {
            get
            {
                return _getTokenRequestRepo = _getTokenRequestRepo ?? new GetTokenRequestRepo(_context);
            }
        }
        public IGetTokenResponseRepo GetTokenResponseRepo
        {
            get
            {
                return _getTokenResponseRepo = _getTokenResponseRepo ?? new GetTokenResponseRepo(_context);
            }
        }
        public ILetRequestLogRepo LetRequestLogRepo
        {
            get
            {
                return _letRequestLogRepo = _letRequestLogRepo ?? new LetRequestLogRepo(_context);
            }
        }
        public ILetResponseLogRepo LetResponseLogRepo
        {
            get
            {
                return _letResponseLogRepo = _letResponseLogRepo ?? new LetResponseLogRepo(_context);
            }
        }
        public IVerifyRequestLogRepo VerifyRequestLogRepo
        {
            get
            {
                return _verifyRequestLogRepo = _verifyRequestLogRepo ?? new VerifyRequestLogRepo(_context);
            }
        }
        public IVerifyResponseLogRepo VerifyResponseLogRepo
        {
            get
            {
                return _verifyResponseLogRepo = _verifyResponseLogRepo ?? new VerifyResponseLogRepo(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
