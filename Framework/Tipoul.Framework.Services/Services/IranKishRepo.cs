using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Shaparak.Services.Data;
using Tipoul.Shaparak.Services.Entity;
using Tipoul.Shaparak.Services.Infrastructure;

namespace Tipoul.Shaparak.Services.Services
{
    public class IranKishRepo:IIrankishSourceRepo
    {
        private ShaparakContext _context;
        public IranKishRepo(ShaparakContext context)
        {
            _context = context;
        }
        public List<IrankishSource> GetAll()
        {
            return _context.IrankishSource.OrderByDescending(r => r.Id).ToList();
        }
        public IrankishSource GetById(int id)
        {
            return _context.IrankishSource.Where(x => x.Id == id).FirstOrDefault();

        }
        public void Insert(IrankishSource irankishsource)
        {
            _context.IrankishSource.Add(irankishsource);
        }
        public void Update(IrankishSource irankishsource)
        {

            _context.IrankishSource.Update(irankishsource);

        }
        public void Delete(int id)
        {
            var adss = _context.IrankishSource.Where(x => x.Id == id).FirstOrDefault();
            _context.IrankishSource.Remove(adss);
        }
    }
}
