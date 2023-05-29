using CustomerManagementAPI.Infrastructure.Interfaces;

namespace CustomerManagementAPI.Infrastructure.Data.Entity
{
    public class CompanyDepartmentMap: IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Company Company { get; set; }

        public CompanyDepartmentMap(int companyId, int departmentId)
        {
            CompanyId = companyId;
            DepartmentId = departmentId;
        }
        public CompanyDepartmentMap() 
        {
        }
    }
}
