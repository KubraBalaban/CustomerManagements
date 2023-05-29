using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.Application.Models.Response;
using MediatR;
using System.Runtime.Serialization;

namespace CustomerManagementAPI.Application.Commands
{
    [DataContract]
    public class DeleteCustomerCommand : IRequest<ResponseModel<DeleteCustomerResponseModel>>
    {
        [DataMember]
        public int Id { get; set; }

    }
}
