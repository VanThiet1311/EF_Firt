using Microsoft.AspNetCore.Mvc;
using MiniEfApi.Services;      // CustomerService
using MiniEfApi.Data;          // Customer Entity
using DTOs = MiniEfApi.Dtos;
using Model = MiniEfApi.Models;

// CustomerModel
namespace MiniEfApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;
        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetCustomersAsync();
            var response = customers.Select(c => new DTOs.CustomerReponseDto
            {
                Name = c.Name,
                Email = c.Email
            }).ToList();
            return Ok(customers);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdCustomerAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Model.Customer model)
        {
            if (model == null)
                return BadRequest();

            var customer = await _service.CreateCustomerAsync(model);
            return CreatedAtAction(
                nameof(GetById),
                new { id = customer.Id },
                customer
         );
        }
        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Model.Customer model)
        {
            if (model == null)
                return BadRequest();

            var customer = await _service.UpdateCustomerAsync(id, model);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCustomerAsync(id);
            if (!result)
                return NotFound();

            return Ok(new { message = "Deleted successfully" });
        }
    }
}
