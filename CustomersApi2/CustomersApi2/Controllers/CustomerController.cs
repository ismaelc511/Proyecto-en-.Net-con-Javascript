using CustomersApi2.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomersApi2.Dtos;
using CustomersApi2.Repositories;

namespace CustomersApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {

        private readonly CustomerDatabaseContext _customerDatabaseContext;

        public CustomerController(CustomerDatabaseContext customerDatabaseContext)
        {
            _customerDatabaseContext = customerDatabaseContext;
        }

        //api/customers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<IActionResult> GetCustomers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomerDto))]
        public async Task<IActionResult> GetCustomer(long id)
        {
            CustomerEntity result = await _customerDatabaseContext.Get(id);

            return new OkObjectResult(result.ToDto());
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customer)
        {
            CustomerEntity result = await _customerDatabaseContext.Add(customer);

            return new CreatedResult($"http://localhost:7154/api/customer/{result.Id}", null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomerDto))]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
