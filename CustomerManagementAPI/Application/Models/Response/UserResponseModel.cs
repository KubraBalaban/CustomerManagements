using CustomerManagementAPI.App.Interfaces;

namespace CustomerManagementAPI.Application.Models.Response
{
    public class UserResponseModel : IViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
