using CustomerManagementAPI.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Infrastructure.Data.Configurations.EntityConfiguration
{
    public class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.CompanyDepartmentMap).WithOne(cd => cd.Company).HasForeignKey(d => d.CompanyId);
        }
    }
}
