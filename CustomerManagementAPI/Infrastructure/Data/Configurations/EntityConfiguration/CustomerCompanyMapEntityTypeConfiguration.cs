using CustomerManagementAPI.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Infrastructure.Data.Configurations.EntityConfiguration
{
    public class CustomerCompanyMapEntityTypeConfiguration : IEntityTypeConfiguration<CustomerCompanyMap>
    {
        public void Configure(EntityTypeBuilder<CustomerCompanyMap> builder)
        {
            builder.ToTable("CustomerCompanyMap");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();

            builder.Property(c => c.CustomerId).IsRequired();

            builder.Property(c => c.CompanyId).IsRequired();
        }
    }
}
