using Microsoft.EntityFrameworkCore;
using Tata.DeviceManagement.Domain.Entities;

namespace Tata.DeviceManagement.Infrastructure.DbContext
{
    public class DeviceDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options) : base(options) { }

        public DbSet<Device> Devices => Set<Device>();
        public DbSet<DeviceConfiguration> DeviceConfigurations => Set<DeviceConfiguration>();
        public DbSet<DevicePort> DevicePorts => Set<DevicePort>();
    }
}
