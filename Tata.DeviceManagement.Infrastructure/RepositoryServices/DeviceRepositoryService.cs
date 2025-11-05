using Microsoft.EntityFrameworkCore;
using Tata.DeviceManagement.Application.Interfaces;
using Tata.DeviceManagement.Domain.Entities;
using Tata.DeviceManagement.Infrastructure.DbContext;
using Tata.DeviceManagement.Infrastructure.RepositoryInterfaces;

namespace Tata.DeviceManagement.Infrastructure.RepositoryServices
{


    public class DeviceRepositoryService : IDeviceRepository
    {
        private readonly DeviceDbContext _context;

        public DeviceRepositoryService(DeviceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Device>> GetAllAsync() =>
            await _context.Devices.Include(d => d.Configuration)
                                  .Include(d => d.Ports)
                                  .ToListAsync();

        public async Task<Device?> GetByIdAsync(Guid id) =>
            await _context.Devices.Include(d => d.Configuration)
                                  .Include(d => d.Ports)
                                  .FirstOrDefaultAsync(d => d.DeviceId == id);

        public async Task<Device> AddAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Device> UpdateAsync(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null) return false;

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return true;
        }

       public async Task<bool> AddInDatabase(List<Device> device)
        {
            await _context.AddRangeAsync(device);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
