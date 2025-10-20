using Microsoft.AspNetCore.Mvc;
using MiniEfApi.Services;      // CustomerService
using MiniEfApi.Entities;          // Customer Entity
using DTOs = MiniEfApi.Dtos;
using Model = MiniEfApi.Models;

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
            var customers = await _service.GetAllCustomersAsync();
            var response = customers.Select(c => new DTOs.CustomerReponseDto
            {
                Name = c.Name,
                Email = c.Email
            }).ToList();
            return Ok(response);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer model)
        {
            if (model == null)
                return BadRequest();

            await _service.AddCustomerAsync(model);
            return CreatedAtAction(
                nameof(GetById),
                new { id = model.Id },
                model
            );
        }

        // PUT: api/customers/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] Customer model)
        // {
        //     if (model == null)
        //         return BadRequest();

        //     var existingCustomer = await _service.GetCustomerByIdAsync(id);
        //     if (existingCustomer == null)
        //         return NotFound();

        //     // Update fields
        //     existingCustomer.Name = model.Name;
        //     existingCustomer.Email = model.Email;

        //     await _service.UpdateCustomerAsync(existingCustomer);
        //     return Ok(existingCustomer);
        // }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            await _service.DeleteCustomerAsync(customer);
            return Ok(new { message = "Deleted successfully" });
        }
    }
}
