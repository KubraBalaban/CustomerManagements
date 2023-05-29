using CustomerManagementAPI.Infrastructure.Interfaces;

namespace CustomerManagementAPI.Infrastructure.Data.Entity
{
    public class Company :BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set;}
        public int CompanyCode { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CompanyDepartmentMap> CompanyDepartmentMap { get; set; }
       
    }
}
