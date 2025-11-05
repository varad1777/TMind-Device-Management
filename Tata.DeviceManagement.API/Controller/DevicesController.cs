using Microsoft.AspNetCore.Mvc;
using Tata.DeviceManagement.API.Models;
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var devices = await _service.GetAllDevicesAsync();
                return Ok(ApiResponse<IEnumerable<Device>>.SuccessResponse("Devices retrieved successfully", devices));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.FailureResponse($"Error fetching devices: {ex.Message}"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var device = await _service.GetDeviceByIdAsync(id);
                if (device == null)
                    return NotFound(ApiResponse<string>.FailureResponse("Device not found"));

                return Ok(ApiResponse<Device>.SuccessResponse("Device retrieved successfully", device));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.FailureResponse($"Error fetching device: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeviceDto device)
        {
            try
            {
                var result = await _service.CreateDeviceAsync(device);
                return CreatedAtAction(nameof(GetById), new { id = result.DeviceId },
                    ApiResponse<Device>.SuccessResponse("Device created successfully", result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.FailureResponse($"Error creating device: {ex.Message}"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DeviceDto device)
        {
            try
            {
                var updated = await _service.UpdateDeviceAsync(id, device);
                if (updated == null)
                    return NotFound(ApiResponse<string>.FailureResponse("Device not found"));

                return Ok(ApiResponse<Device>.SuccessResponse("Device updated successfully", updated));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.FailureResponse($"Error updating device: {ex.Message}"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _service.DeleteDeviceAsync(id);
                if (!result)
                    return NotFound(ApiResponse<string>.FailureResponse("Device not found"));

                return Ok(ApiResponse<string>.SuccessResponse("Device deleted successfully", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.FailureResponse($"Error deleting device: {ex.Message}"));
            }
        }
    }
}
