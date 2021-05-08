using efcore_domain_event.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace efcore_domain_event.Infrastructure
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25);
            builder.OwnsOne(x => x.Discount);

            builder.OwnsMany(x => x.Orders);
            builder.Navigation(x => x.Orders).Metadata.SetField("_orders");
            builder.Navigation(x => x.Orders).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}