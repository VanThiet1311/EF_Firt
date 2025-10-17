using Microsoft.AspNetCore.Mvc;
using MiniEfApi.Services;      
using Model = MiniEfApi.Models;

namespace MiniEfApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _service;

        public AddressesController(AddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _service.GetAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _service.GetByIdAddressAsync(id);
            if (address == null)
                return NotFound(new { message = "Address not found" });

            return Ok(address);
        }

        // ✅ POST: api/addresses
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Model.Address model)
        {
            if (model == null)
                return BadRequest(new { message = "Invalid address data" });

            var address = await _service.CreateAddressAsync(model);
            return CreatedAtAction(
                nameof(GetById),
                new { id = address.Id },
                address
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Model.Address model)
        {
            if (model == null)
                return BadRequest();

            var address = await _service.UpdateAddressAsync(id, model);
            if (address == null)
                return NotFound(new { message = "Address not found" });

            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAddressAsync(id);
            if (!result)
                return NotFound(new { message = "Address not found" });

            return Ok(new { message = "Deleted successfully" });
        }
    }
}
