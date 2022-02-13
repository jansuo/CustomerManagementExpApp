using CustomersDAL.Models;
using CustomersDAL.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersDAL.Services
{
    public interface ICustomerService
    {
        Task<IReadOnlyList<Customer>> GetAll();
        Task<CreateCustomerResult> CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Guid Id);
    }
}