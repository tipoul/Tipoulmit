using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Shaparak.Services.Entity;

namespace Tipoul.Shaparak.Services.Infrastructure
{
    public interface IIrankishSourceRepo
    {
        List<IrankishSource> GetAll();
        IrankishSource GetById(int id);
        void Insert(IrankishSource irankishSource);
        void Update(IrankishSource irankishSource);
        void Delete(int irankishSource);
    }
}
