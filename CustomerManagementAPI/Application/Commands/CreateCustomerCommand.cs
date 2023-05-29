using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.Application.Models.Response;
using MediatR;
using System.Runtime.Serialization;

namespace CustomerManagementAPI.Application.Commands
{
    [DataContract]
    public class CreateCustomerCommand : IRequest<ResponseModel<CreateCustomerResponseModel>>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public int? Age { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }


        public CreateCustomerCommand(string name, string surname, int age, string email, string gender, bool isActive, DateTime createdDate)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Gender = gender;
            IsActive = isActive;
            CreatedDate = createdDate;
        }

        public CreateCustomerCommand() { }

    }
}
