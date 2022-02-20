using CustomersBLL.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersBLL.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();
    }
}