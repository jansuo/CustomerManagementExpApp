using CustomersAPI.Mappers;
using CustomersAPI.Models;
using CustomersDAL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OneOf;
using FluentValidation;
using CustomersAPI.Errors;
using System;
using FluentValidation.Results;

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
            if (dbResult == null || dbResult.Count == 0) return null;
            var result = dbResult.Select(x => x.ToModel()).ToList();
            return result;
        }

        public async Task<UpdateCustomerResponse> UpdateCustomer(CustomerModel customer)
        {
            var validateResult = _validator.Validate(customer);
            if (!validateResult.IsValid)
            {
                var errorMessages = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return new UpdateCustomerResponse
                {
                    ValidationError = new CustomerValidationError
                    {
                        Messages = errorMessages
                    }
                };
            }

            var updateResult = new UpdateCustomerResponse();
            if (customer.Id == Guid.Empty)
            {
                updateResult.responseType = Enums.UpdateCustomerResponseType.Create;
                var dbResult = await _customerService.CreateCustomer(customer.ToDto());
                updateResult.Id = dbResult.Id;
            }
            else
            {
                updateResult.responseType = Enums.UpdateCustomerResponseType.Update;
                updateResult.Id = customer.Id;
                await _customerService.UpdateCustomer(customer.ToDto());
            }
            return updateResult;
        }

        public async Task DeleteCustomer(Guid Id)
        {
            await _customerService.DeleteCustomer(Id);
        }

        public async Task<CustomerModel> GetCustomerById(Guid Id)
        {
            var customer = await _customerService.GetCustomer(Id);
            return customer.ToModel();
        }
    }
}
