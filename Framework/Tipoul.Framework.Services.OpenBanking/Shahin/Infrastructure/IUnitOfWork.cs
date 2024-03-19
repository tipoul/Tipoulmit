using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Services;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure
{
    public interface IUnitOfWork
    {
        IIbansRepo IbansRepo { get; }
        ISourcesRepo SourcesRepo { get; }
        IBanksRepo BanksRepo { get; }
        ICardInfosRepo CardInfosRepo { get; }

        void Save();
    }
}
