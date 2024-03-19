using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure
{
    public interface ICardInfosRepo
    {
        void Insert(CardInfos cardinfo);

    }
}
