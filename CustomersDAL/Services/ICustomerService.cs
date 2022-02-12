using CustomersDAL.Models;
using CustomersDAL.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersDAL.Services
{
    public interface ICustomerService
    {
        Task<IReadOnlyList<Customer>> GetAll();
        Task<CreateCustomerResult> CreateCustomer(Customer customer);
    }
}