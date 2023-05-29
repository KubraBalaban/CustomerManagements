using AutoMapper;
using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.Application.Constant;
using CustomerManagementAPI.Application.Models.Response;
using CustomerManagementAPI.Infrastructure.Data.Context;
using CustomerManagementAPI.Infrastructure.Data.Entity;

using MediatR;


namespace CustomerManagementAPI.Application.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseModel<CreateCustomerResponseModel>>
    {
        private readonly CustomerContext _customerContext;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(CustomerContext customerContext, IMapper mapper)
        {
            _customerContext = customerContext;
            _mapper = mapper;
        }
        public async Task<ResponseModel<CreateCustomerResponseModel>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Customer(request.Name, request.Surname, request.Age, request.Email, request.Gender);
                customer.CreatedDate = DateTime.UtcNow;
                _customerContext.Customers.Add(customer);
                _customerContext.SaveChanges();

                var response = _mapper.Map<CreateCustomerResponseModel>(customer);
                return ResponseModel<CreateCustomerResponseModel>.Success(response, ResponseMessage.Success.CustomerCreateSuccessful);
            }
            catch (Exception ex) 
            {
                return ResponseModel<CreateCustomerResponseModel>.Fail(ResponseMessage.Error.CustomerCreateFailed);
            }
            
        }

      
    }
}
