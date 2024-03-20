using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Shaparak.Services.Data;
using Tipoul.Shaparak.Services.Entity;

namespace Tipoul.Shaparak.Services.Services
{
    internal class SepehrRepo
    {

        private Context _context;
        public SepehrRepo(Context context)
        {
            _context = context;
        }
        public List<SepehrSource> GetAll()
        {
            return _context.SepehrSource.OrderByDescending(r => r.Id).ToList();
        }
        public SepehrSource GetById(int id)
        {
            return _context.SepehrSource.Where(x => x.Id == id).FirstOrDefault();

        }
        public void Insert(SepehrSource sepehrSource)
        {
            _context.SepehrSource.Add(sepehrSource);
        }
        public void Update(SepehrSource sepehrSource)
        {

            _context.SepehrSource.Update(sepehrSource);

        }
        public void Delete(int id)
        {
            var adss = _context.SepehrSource.Where(x => x.Id == id).FirstOrDefault();
            _context.SepehrSource.Remove(adss);
        }
    }
}
