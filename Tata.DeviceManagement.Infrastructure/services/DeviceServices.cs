
using Tata.DeviceManagement.Application.DTOs;
using Tata.DeviceManagement.Application.Interfaces;
using Tata.DeviceManagement.Domain.Entities;
using Tata.DeviceManagement.Infrastructure.RepositoryInterfaces;

namespace Tata.DeviceManagement.Infrastructure.services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repo;

        public DeviceService(IDeviceRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch devices: {ex.Message}", ex);
            }
        }

        public async Task<Device?> GetDeviceByIdAsync(Guid id)
        {
            try
            {
                return await _repo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving device with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<Device> CreateDeviceAsync(DeviceDto device)
        {
            try
            {
                var dev = new Device
                {
                    DeviceId = Guid.NewGuid(),
                    Name = device.Name,
                    Description = device.Description,
                    Protocol = device.Protocol
                };

                return await _repo.AddAsync(dev);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create device: {ex.Message}", ex);
            }
        }

        public async Task<Device?> UpdateDeviceAsync(Guid id, DeviceDto device)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null) return null;

                existing.Name = device.Name;
                existing.Description = device.Description;
                existing.Protocol = device.Protocol;

                return await _repo.UpdateAsync(existing);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update device with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteDeviceAsync(Guid id)
        {
            try
            {
                return await _repo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete device with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
