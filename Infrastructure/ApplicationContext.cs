using efcore_domain_event.Domain;
using Microsoft.EntityFrameworkCore;

namespace efcore_domain_event.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DomainEvent;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}
