using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.Application.Models;
using CustomerManagementAPI.Application.Models.Response;

namespace CustomerManagementAPI.Application.Queries
{
    public interface ICustomerQueries
    {
        ResponseModel<List<CustomerResponseModel>> GetAllCustomers();
        ResponseModel<List<CompanyResponseModel>> GetAllCompanies();

        ResponseModel<List<CustomerResponseModel>> GetAllCustomersById(int id);
    }
}
