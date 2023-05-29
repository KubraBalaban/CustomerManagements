using CustomerManagementAPI.Infrastructure.Interfaces;

namespace CustomerManagementAPI.Infrastructure.Data.Entity
{
    public class Department : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public int ShortCode { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<CompanyDepartmentMap> CompanyDepartmentMap { get; set; }
    }
}
