using CustomersAPI.Errors;
using CustomersAPI.Models;
using OneOf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersAPI.ControllerServices
{
    public interface ICustomerControllerService
    {
        Task<IReadOnlyList<CustomerModel>> GetCustomers();
        Task<UpdateCustomerResponse> UpdateCustomer(CustomerModel customer);
        Task DeleteCustomer(Guid Id);
    }
}