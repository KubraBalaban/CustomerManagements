﻿namespace CustomerManagementAPI.Application.Models.Response
{
    public class DeleteCustomerResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
