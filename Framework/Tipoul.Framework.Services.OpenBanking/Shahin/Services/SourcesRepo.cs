
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
    public class SourcesRepo : ISourcesRepo
    {
        private Context _context;
        public SourcesRepo(Context context)
        {
            _context = context;
        }

        public Source GetById(int id)
        {
            var source = _context.Source.Where(x => x.Id == id).FirstOrDefault();
            return source;
        }

        public Source GetByActive()
        {
            var source = _context.Source.Where(x => x.ActiveState == true).FirstOrDefault();
            return source;
        }

    }
}

