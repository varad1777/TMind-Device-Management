using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tata.DeviceManagement.Application.DTOs;
using Tata.DeviceManagement.Domain.Entities;

namespace Tata.DeviceManagement.Application.Interfaces
{


    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device?> GetDeviceByIdAsync(Guid id);
        Task<Device> CreateDeviceAsync(DeviceDto device);
        Task<Device> UpdateDeviceAsync(Guid id, DeviceDto device);
        Task<bool> DeleteDeviceAsync(Guid id);
        Task<IEnumerable<DevicePort>> GetPortsByDeviceAsync(Guid deviceId, bool activeOnly);
        Task ReplacePortSetAsync(Guid deviceId);
        Task CreateDefaultPortsForDevice(Guid deviceId, int version);



    }
}
