using System.ComponentModel;

namespace CustomerManagementAPI.Infrastructure.Data.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public BaseEntity() 
        {
            CreatedDate = DateTime.Now;
        }
    }
}
