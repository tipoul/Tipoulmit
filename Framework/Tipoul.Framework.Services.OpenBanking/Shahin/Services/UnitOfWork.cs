using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Data;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private OpenBankingContext _context;
        private IIbansRepo _ibansRepo;
        private ISourcesRepo _sourcesRepo;
        private IBanksRepo _banksRepo;
        private ICardInfosRepo _cardInfosRepo;

        public UnitOfWork(OpenBankingContext context)
        {
            _context = context;
        }
        public IIbansRepo IbansRepo
        {
            get
            {
                return _ibansRepo = _ibansRepo ?? new IbansRepo(_context);
            }
        }
        public ISourcesRepo SourcesRepo
        {
            get
            {
                return _sourcesRepo = _sourcesRepo ?? new SourcesRepo(_context);
            }
        }

        public IBanksRepo BanksRepo
        {
            get
            {
                return _banksRepo = _banksRepo ?? new BanksRepo(_context);
            }
        }


        public ICardInfosRepo CardInfosRepo
        {
            get
            {
                return _cardInfosRepo = _cardInfosRepo ?? new CardInfosRepo(_context);
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
