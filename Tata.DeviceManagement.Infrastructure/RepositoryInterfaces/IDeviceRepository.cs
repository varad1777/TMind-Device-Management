using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tata.DeviceManagement.Domain.Entities;

namespace Tata.DeviceManagement.Infrastructure.RepositoryInterfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device?> GetByIdAsync(Guid id);
        Task<Device> AddAsync(Device device);
        Task<Device> UpdateAsync(Device device);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> AddInDatabase(List<Device> device);
    }
}
