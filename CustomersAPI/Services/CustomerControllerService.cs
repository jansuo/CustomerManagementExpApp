using CustomersAPI.Mappers;
using CustomersBLL.Models;
using CustomersDAL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OneOf;
using FluentValidation;
using CustomersAPI.Errors;
using System;

namespace CustomersAPI.ControllerServices
{

    public class CustomerControllerService : ICustomerControllerService
    {
        private readonly ICustomerService _customerService;
        private readonly IValidator<CustomerModel> _validator;

        public CustomerControllerService(
            ICustomerService customerService, 
            IValidator<CustomerModel> validator)
        {
            _customerService = customerService;
            _validator = validator;
        }

        public async Task<IReadOnlyList<CustomerModel>> GetCustomers()
        {
            var dbResult = await _customerService.GetAll();
            var result = dbResult.Select(x => x.DtoToModel()).ToList();
            return result;
        }

        public async Task<OneOf<Guid, CustomerValidationError>> CreateCustomer(CustomerModel customer)
        {
            var validateResult = _validator.Validate(customer);
            if (!validateResult.IsValid)
            {
                var errorMessages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return new CustomerValidationError
                {
                    Messages = errorMessages
                };
            }
            
            var result = await _customerService.CreateCustomer(customer.ModelToDto());
            return result.Id;
        }
    }
}
