using Microsoft.EntityFrameworkCore;
using Quotey.Persistence.SqlServer.Entities;

namespace Quotey.Persistence.SqlServer
{
    public partial class QuoteyContext : DbContext
    {
        public QuoteyContext()
        {
        }

        public QuoteyContext(DbContextOptions<QuoteyContext> options)
            : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Quote>()
                .HasKey(c => c.Id);
        }
    }
}
