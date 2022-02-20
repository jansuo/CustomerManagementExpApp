using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersBLL.Api.Models;
using CustomersBLL.Api.Responses;
using Refit;

namespace CustomersBLL.Api
{
    public interface ICustomersApi
    {
        [Get("/customers")]
        Task<List<Customer>> GetCustomersAsync();
    }
}
