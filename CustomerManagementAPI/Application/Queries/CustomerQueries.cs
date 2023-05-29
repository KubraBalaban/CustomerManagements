using AutoMapper;
using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.Application.Constant;
using CustomerManagementAPI.Application.Models;
using CustomerManagementAPI.Application.Models.Response;
using CustomerManagementAPI.Infrastructure.Data.Context;

namespace CustomerManagementAPI.Application.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        #region Fields
        private readonly CustomerContext _customerContext;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public CustomerQueries(CustomerContext customerContext, IMapper mapper)
        {
            _customerContext = customerContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public ResponseModel<List<CustomerResponseModel>> GetAllCustomers()
        {
            try
            {
                var customer = _customerContext.Customers.Where(x => x.IsActive).ToList();

                if (customer?.Any() ?? false)
                {
                    var response = _mapper.Map<List<CustomerResponseModel>>(customer);
                    return ResponseModel<List<CustomerResponseModel>>.Success(response, ResponseMessage.Success.Successful);
                }
            }
            catch
            {

            }

            return ResponseModel<List<CustomerResponseModel>>.Fail(ResponseMessage.Error.Fail);
        }

        public ResponseModel<List<CompanyResponseModel>> GetAllCompanies()
        {
            try
            {
                var customer = _customerContext.Companies.Where(x => x.IsActive).ToList();
                var response = _mapper.Map<List<CompanyResponseModel>>(customer);
                return ResponseModel<List<CompanyResponseModel>>.Success(response, ResponseMessage.Success.Successful);
            }
            catch (Exception ex)
            {
                return ResponseModel<List<CompanyResponseModel>>.Fail(ResponseMessage.Error.Fail);
            }
        }

        public ResponseModel<List<CustomerResponseModel>> GetAllCustomersById(int id)
        {
            try
            {
                var itemCustomer = _customerContext.Customers.Where(x => x.Id == id).ToList();
                var response = _mapper.Map<List<CustomerResponseModel>>(itemCustomer);
                return ResponseModel<List<CustomerResponseModel>>.Success(response, ResponseMessage.Success.Successful);
            }
            catch (Exception ex)
            {
                return ResponseModel<List<CustomerResponseModel>>.Fail(ResponseMessage.Error.Fail);
            }
        }
        #endregion
    }
}
