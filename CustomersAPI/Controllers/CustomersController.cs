using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomersDAL.Services;
using CustomersDAL.Models;
using CustomersAPI.ControllerServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomersBLL.Models;

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
            var formattedResult = "";
            var hasError = false;
            var result = await _customerControllerService.CreateCustomer(customer);
            result.Switch(guid =>
            {
                formattedResult = guid.ToString();
            }, error =>
            {
                hasError = true;
                formattedResult = string.Join(", ", error.Messages);
            });
            if (hasError) return BadRequest(formattedResult);

            return Ok(formattedResult);
        }
    }
}
