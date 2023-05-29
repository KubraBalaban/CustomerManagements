using CustomerManagementAPI.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Infrastructure.Data.Configurations.EntityConfiguration
{
    public class CompanyDepartmentMapEntityTypeConfiguration : IEntityTypeConfiguration<CompanyDepartmentMap>
    {
        public void Configure(EntityTypeBuilder<CompanyDepartmentMap> builder)
        {
            builder.ToTable("CompanyDepartmentMap");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();

            builder.Property(c => c.CompanyId).IsRequired();

            builder.Property(c => c.DepartmentId).IsRequired();
        }
    }
}
