using AutoMapper;
using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.Application.Constant;
using CustomerManagementAPI.Application.Models.Response;
using CustomerManagementAPI.Infrastructure.Data.Context;
using MediatR;

namespace CustomerManagementAPI.Application.Commands.CommandHandlers
{
    public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, ResponseModel<UpdateCustomerResponseModel>>
    {
        private readonly CustomerContext _customerContext;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(CustomerContext customerContext, IMapper mapper)
        {
            _customerContext = customerContext;
            _mapper = mapper;
        }
        public async Task<ResponseModel<UpdateCustomerResponseModel>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerContext.Customers.FirstOrDefault(p => p.Id == request.Id);
                if (customer != null)
                {
                    customer.UpdatedDate = DateTime.UtcNow;
                    customer.IsActive = request.IsActive;
                    customer.Name = request.Name;
                    customer.Email = request.Email;
                    customer.Age = request.Age;
                    customer.Surname = request.Surname;
                    customer.Gender = request.Gender;
                    _customerContext.Customers.Update(customer);
                    _customerContext.SaveChanges();
                }

                var response = _mapper.Map<UpdateCustomerResponseModel>(customer);
                return ResponseModel<UpdateCustomerResponseModel>.Success(response, ResponseMessage.Success.CustomerUpdateSuccessful);
            }
            catch(Exception e)
            {
                return ResponseModel<UpdateCustomerResponseModel>.Fail(ResponseMessage.Error.CustomerUpdateFailed);
            }

        }
    }
}
