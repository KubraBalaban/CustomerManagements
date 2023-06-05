using AutoMapper;
using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.Application.Constant;
using CustomerManagementAPI.Application.Models.Response;
using CustomerManagementAPI.Infrastructure.Data.Context;
using MediatR;

namespace CustomerManagementAPI.Application.Commands.CommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResponseModel<DeleteCustomerResponseModel>>
    {
        private readonly CustomerContext _customerContext;
        private readonly IMapper _mapper;
        public DeleteCustomerCommandHandler(CustomerContext customerContext, IMapper mapper)
        {
            _customerContext = customerContext;
            _mapper = mapper;
        }
        public async Task<ResponseModel<DeleteCustomerResponseModel>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerContext.Customers.FirstOrDefault(x => x.Id == request.Id);
                var customerMap = _customerContext.CustomerCompanyMaps.FirstOrDefault(x => x.CustomerId == customer.Id);
                if (customerMap != null)
                {
                    _customerContext.CustomerCompanyMaps.Remove(customerMap);
                    _customerContext.SaveChanges();
                    if (customer != null)
                    {
                        _customerContext.Customers.Remove(customer);
                        _customerContext.SaveChanges();
                    }

                }
                else
                {
                    if (customer != null)
                    {
                        _customerContext.Customers.Remove(customer);
                        _customerContext.SaveChanges();
                    }
                }
                var response = _mapper.Map<DeleteCustomerResponseModel>(customer);
                return ResponseModel<DeleteCustomerResponseModel>.Success(response, ResponseMessage.Success.CustomerDeleteSuccessful);
            }

            catch (Exception e)
            {
                return ResponseModel<DeleteCustomerResponseModel>.Fail(ResponseMessage.Error.CustomerDeleteFailed);
            }

        }
    }
}
