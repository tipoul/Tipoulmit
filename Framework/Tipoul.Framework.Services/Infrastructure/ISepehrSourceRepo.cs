using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Shaparak.Services.Entity;

namespace Tipoul.Shaparak.Services.Infrastructure
{
    public interface ISepehrSourceRepo
    {
        List<SepehrSource> GetAll();
        SepehrSource GetById(int id);
        void Insert(SepehrSource sepehrSource);
        void Update(SepehrSource sepehrSource);
        void Delete(int sepehrSource);
    }
}
