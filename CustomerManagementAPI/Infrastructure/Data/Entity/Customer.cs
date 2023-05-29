using CustomerManagementAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Infrastructure.Data.Entity
{
    [Index(nameof(Id))]
    [Index(nameof(Name))]
    [Index(nameof(Email))]
    public class Customer : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<CustomerCompanyMap> CustomerCompanyMap { get; set; }

        public Customer(string name, string surname, int? age, string email, string gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Gender = gender;
        }
    }
}
