using CustomerManagementAPI.Infrastructure.Data.Configurations.EntityConfiguration;
using CustomerManagementAPI.Infrastructure.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CustomerManagementAPI.Infrastructure.Data.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CustomerCompanyMap> CustomerCompanyMaps { get; set; }
        public DbSet<CompanyDepartmentMap> CompanyDepartmentMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyEntityTypeConfiguration());
            builder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            builder.ApplyConfiguration(new DepartmentEntityTypeConfiguration());
            builder.ApplyConfiguration(new CompanyDepartmentMapEntityTypeConfiguration());
            builder.ApplyConfiguration(new CustomerCompanyMapEntityTypeConfiguration());
        }
    }

    public class CustomerContextDesignFactory : IDesignTimeDbContextFactory<CustomerContext>
    {
        public CustomerContextDesignFactory()
        {

        }
        public CustomerContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                .AddEnvironmentVariables()
                                                .Build();

            var connectionString = configuration["UserConnectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>()
                .UseNpgsql(connectionString);
            return new CustomerContext(optionsBuilder.Options);
        }
    }
}
