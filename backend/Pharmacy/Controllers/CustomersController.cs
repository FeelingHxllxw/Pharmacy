using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Contracts;
using PharmacyStore.Core.Models;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController :ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<CustomersResponse>>> GetCustomers()
        {
            var customers = await _customersService.GetAllCustomers();

            var responce = customers.Select(b => new CustomersResponse(b.Customer_Id, b.Last_Name, b.First_Name, b.Middle_Name, b.Addres, b.City, b.Phone));

            return Ok(responce);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomersResponse>> GetByIdCustomer(Guid id)
        {
            var customer = await _customersService.GetCustomerById(id);
            var response = new CustomersResponse(customer.Customer_Id, customer.Last_Name, customer.First_Name, customer.Middle_Name, customer.Addres, customer.City, customer.Phone);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCustomer([FromBody] CustomersRequest request)
        {
            var (customer, error) = Customer.Create(Guid.NewGuid(), request.Last_Name, request.First_Name, request.Middle_Name, request.Addres, request.City, request.Phone);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _customersService.CreateCustomer(customer);

            return Ok(customer.Customer_Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCustomer(Guid id, [FromBody] CustomersRequest request)
        {
            var customerId = await _customersService.UpdateCustomer(id, request.Last_Name, request.First_Name, request.Middle_Name, request.Addres, request.City, request.Phone);

            return Ok(customerId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCustomer(Guid id)
        {
            return Ok(await _customersService.DeleteCustomer(id));
        }
    }
}
