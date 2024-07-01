using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Shaparak.Services.Entity;

namespace Tipoul.Shaparak.Services.Data
{

    public class ShaparakContext : DbContext
    {
        public ShaparakContext(DbContextOptions<ShaparakContext> options) : base(options)
        {
        }
        public DbSet<BehpardakhtSource> BehpardakhtSource { get; set; }
        public DbSet<SepehrSource> SepehrSource { get; set; }
        public DbSet<IrankishSource> IrankishSource { get; set; }

    }
}
