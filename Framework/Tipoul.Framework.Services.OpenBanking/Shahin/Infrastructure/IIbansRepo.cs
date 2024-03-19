using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;


namespace Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure
{
    public interface IIbansRepo
    {
        void Insert(Ibans iban);
    }
}
