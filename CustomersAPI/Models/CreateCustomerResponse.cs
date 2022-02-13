using CustomersAPI.Errors;
using System;

namespace CustomersAPI.Models
{
    public struct UpdateCustomerResponse
    {
        public Guid Id { get; set; }
        public CustomerValidationError ValidationError { get; set; }
    }
}
