using CustomersAPI.Errors;
using CustomersBLL.Models;
using OneOf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersAPI.ControllerServices
{
    public interface ICustomerControllerService
    {
        Task<IReadOnlyList<CustomerModel>> GetCustomers();
        Task<OneOf<Guid, CustomerValidationError>> CreateCustomer(CustomerModel customer);
    }
}