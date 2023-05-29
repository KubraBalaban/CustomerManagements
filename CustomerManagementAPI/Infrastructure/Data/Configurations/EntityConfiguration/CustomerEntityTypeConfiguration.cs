using CustomerManagementAPI.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Infrastructure.Data.Configurations.EntityConfiguration
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.CustomerCompanyMap).WithOne(cd => cd.Customer).HasForeignKey(d => d.CustomerId);
        }
    }
}
