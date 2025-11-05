using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Device>> GetAllDevicesAsync() => await _repo.GetAllAsync();
        public async Task<Device?> GetDeviceByIdAsync(Guid id) => await _repo.GetByIdAsync(id);
        public async Task<Device> CreateDeviceAsync(DeviceDto device)  {
            
            Device dev = new Device
            {
                DeviceId = new Guid(),
                Name = device.Name,
                Description = device.Description,
                Protocol = device.Protocol,
               
            };
           return await _repo.AddAsync(dev);
        }
        public async Task<Device> UpdateDeviceAsync(Guid id, DeviceDto device)
        {
            Device existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                // not found -> return null (caller can return 404)
                return null;
            }
            existing.Name = device.Name;
            existing.Description = device.Description;
            existing.Protocol = device.Protocol;
            return await _repo.UpdateAsync(existing);

        }
        public async Task<bool> DeleteDeviceAsync(Guid id) => await _repo.DeleteAsync(id);
    }


}
