using CustomersBLL.Models;
using CustomersDAL.Models;

namespace CustomersAPI.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerModel DtoToModel(this Customer customer)
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

        public static Customer ModelToDto(this CustomerModel model)
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
