using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomersDAL.Services;
using CustomersDAL.Models;
using CustomersAPI.ControllerServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomersAPI.Models;
using System;

namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerControllerService _customerControllerService;

        public CustomersController(ICustomerControllerService customerControllerService)
        {
            _customerControllerService = customerControllerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _customerControllerService.GetCustomers());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel customer)
        {
            return await CommitUpdateCustomer(customer);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody]CustomerModel customer)
        {
            if (customer.Id == Guid.Empty) return NotFound(new { error = "Id is empty" });
            return await CommitUpdateCustomer(customer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid Id)
        {
            await _customerControllerService.DeleteCustomer(Id);
            return Ok();
        }

        private async Task<IActionResult> CommitUpdateCustomer(CustomerModel customer)
        {
            if (customer == null) return BadRequest(new { error = "Object is null" });
            var result = await _customerControllerService.UpdateCustomer(customer);

            if (result.ValidationError != null) return BadRequest(result);
            switch (result.responseType)
            {
                case Enums.UpdateCustomerResponseType.Create: 
                    return Ok(result);
                default:
                    return Ok(result);
            } 
        }
    }
}
