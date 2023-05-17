using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.DataAccess.DBContexts
{
    public class TaxPayersApplicationContext : DbContext
    {
        public TaxPayersApplicationContext(DbContextOptions<TaxPayersApplicationContext> options) : base(options)
        {
        }

        public DbSet<TaxPayers> TaxPayers { get; set; }
        public DbSet<TaxReceipt> TaxReceipt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
