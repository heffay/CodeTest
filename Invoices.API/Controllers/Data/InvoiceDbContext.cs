using Microsoft.EntityFrameworkCore;

namespace Invoices.API.Data
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options){

        }

        public DbSet<Invoice> Invoices{get;set;}
        public DbSet<InvoiceLine> InvoiceLines{get;set;}

        protected override void OnModelCreating(ModelBuilder builder){

            
            base.OnModelCreating(builder);
        }
    }
}