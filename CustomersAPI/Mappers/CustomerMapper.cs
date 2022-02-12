using CustomersAPI.Models;
using CustomersDAL.Models;

namespace CustomersAPI.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerModel ToModel(this Customer customer)
        {
            return new()
            {
                Company = customer.Company,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Id = customer.Id
            };
        }

        public static Customer ToDto(this CustomerModel model)
        {
            return new()
            {
                Company = model.Company,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Id = model.Id
            };
        }
    }
}
