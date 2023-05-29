namespace CustomerManagementAPI.Infrastructure.Data.Entity
{
    public class CustomerCompanyMap
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Customer Customer { get; set; }

        public CustomerCompanyMap(int companyId, int customerId)
        {
            CompanyId = companyId;
            CustomerId = customerId;
        }
        public CustomerCompanyMap()
        {
        }
    }
}
