using AutoMapper;
using CustomerManagementAPI.Application.Models;
using CustomerManagementAPI.Application.Models.Response;
using CustomerManagementAPI.Infrastructure.Data.Entity;

namespace CustomerManagementAPI.App.Mapping
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Customer, CreateCustomerResponseModel>();
            CreateMap<Customer, UpdateCustomerResponseModel>();
            CreateMap<Customer, DeleteCustomerResponseModel>();
            CreateMap<Customer, CustomerResponseModel>();
            CreateMap<Company, CompanyResponseModel>();
        }
    }
}
