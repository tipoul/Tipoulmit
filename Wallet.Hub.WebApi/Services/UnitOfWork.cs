using Microsoft.EntityFrameworkCore;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;

namespace Wallet.Hub.WebApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private HubWebApiContext _context;
        private IGetTokenRequestRepo _getTokenRequestRepo;
        private IGetTokenResponseRepo _getTokenResponseRepo;
        private ILetRequestLogRepo _letRequestLogRepo;
        private ILetResponseLogRepo _letResponseLogRepo;
        private IVerifyRequestLogRepo _verifyRequestLogRepo;
        private IVerifyResponseLogRepo _verifyResponseLogRepo;
        public UnitOfWork(HubWebApiContext context)
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
