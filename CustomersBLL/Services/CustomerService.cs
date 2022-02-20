using CustomersBLL.Api;
using CustomersBLL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersBLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersApi _customersApi;

        public CustomerService(ICustomersApi customersApi)
        {
            _customersApi = customersApi;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var response = await _customersApi.GetCustomersAsync();
            if (response == null) return null;

            var result = new List<Customer>();
            result.AddRange(response);
            return result;
        }
    }
}
