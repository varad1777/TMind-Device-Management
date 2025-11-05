using Microsoft.AspNetCore.Mvc;
using Tata.DeviceManagement.Application.DTOs;
using Tata.DeviceManagement.Application.Interfaces;
using Tata.DeviceManagement.Domain.Entities;

namespace Tata.DeviceManagement.API.Controller
{


    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _service;

        public DeviceController(IDeviceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllDevicesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var device = await _service.GetDeviceByIdAsync(id);
            return device == null ? NotFound() : Ok(device);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeviceDto device)
        {
            var result = await _service.CreateDeviceAsync(device);
            return CreatedAtAction(nameof(GetById), new { id = result.DeviceId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DeviceDto device)
        {
            return Ok(await _service.UpdateDeviceAsync( id, device));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteDeviceAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
