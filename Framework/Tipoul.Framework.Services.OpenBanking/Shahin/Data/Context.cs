using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Entity;


namespace Tipoul.Framework.Services.OpenBanking.Shahin.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ibans> Iban { get; set; }
        public DbSet<Banks> Banks { get; set; }
      
        public DbSet<Source> Source { get; set; }
        public DbSet<CardInfos> CardInfos { get; set; }
    }
}
