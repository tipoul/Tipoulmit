using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Shaparak.Services.Entity;

namespace Tipoul.Shaparak.Services.Infrastructure
{
    public interface IBehpardakhtSourceRepo
    {
        List<BehpardakhtSource> GetAll();
        BehpardakhtSource GetById(int id);
        void Insert(BehpardakhtSource behpardakhtSource);
        void Update(BehpardakhtSource behpardakhtSource);
        void Delete(int behpardakhtSource);
    }
}
