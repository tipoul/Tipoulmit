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
    public class BehpardakhtRepo : IBehpardakhtSourceRepo
    {
        private Context _context;
        public BehpardakhtRepo(Context context)
        {
            _context = context;
        }
        public List<BehpardakhtSource> GetAll()
        {
            return _context.BehpardakhtSource.OrderByDescending(r => r.Id).ToList();
        }
        public BehpardakhtSource GetById(int id)
        {
            return _context.BehpardakhtSource.Where(x => x.Id == id).FirstOrDefault();

        }
        public void Insert(BehpardakhtSource behpardakhtSource)
        {
            _context.BehpardakhtSource.Add(behpardakhtSource);
        }
        public void Update(BehpardakhtSource behpardakhtSource)
        {

            _context.BehpardakhtSource.Update(behpardakhtSource);

        }
        public void Delete(int id)
        {
            var adss = _context.BehpardakhtSource.Where(x => x.Id == id).FirstOrDefault();
            _context.BehpardakhtSource.Remove(adss);
        }
    }
}
