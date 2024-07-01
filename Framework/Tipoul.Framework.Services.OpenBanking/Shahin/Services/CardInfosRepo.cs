
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Data;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;


namespace Tipoul.Framework.Services.OpenBanking.Shahin.Services
{
    public class CardInfosRepo : ICardInfosRepo
    {
        private OpenBankingContext _context;
        public CardInfosRepo(OpenBankingContext context)
        {
            _context = context;
        }
       
        public void Insert(CardInfos cardinfo)
        {
            _context.CardInfos.Add(cardinfo);
        }
      
    }
}

