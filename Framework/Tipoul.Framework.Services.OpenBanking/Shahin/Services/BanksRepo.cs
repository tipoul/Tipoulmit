
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Data;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Services
{
    public class BanksRepo : IBanksRepo
    {
        private Context _context;
        public BanksRepo(Context context)
        {
            _context = context;
        }
        public Banks GetByCode(string code)
        {
            try
            {
                var bank = _context.Banks.Where(x => x.ShahinCode == code).FirstOrDefault();
                return bank;
            }
            catch(Exception ex) {
                var m = "";
                return null;
            }
        }


    }
}

