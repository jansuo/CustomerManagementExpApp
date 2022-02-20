using CustomersBLL.Api.Models;

namespace CustomersBLL.Api.Responses
{
    public record CustomersResponse
    {
        public Customer[] Customers { get; set; }
    }
}
