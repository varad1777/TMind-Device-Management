using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.EntityFrameworkCore;
using Tata.DeviceManagement.Application.DTOs;
using Tata.DeviceManagement.Application.Interfaces;
using Tata.DeviceManagement.Domain.Entities;
using Tata.DeviceManagement.Infrastructure.DbContext;
using Tata.DeviceManagement.Infrastructure.RepositoryInterfaces;

namespace Tata.DeviceManagement.Infrastructure.services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repo;
        
        private readonly DeviceDbContext _context;

        public DeviceService(IDeviceRepository repo, DeviceDbContext context)
        {
            _repo = repo;
            _context = context;
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

                Device dev2 =  await _repo.AddAsync(dev);
                await CreateDefaultPortsForDevice(dev2.DeviceId, 1);
                return dev2;
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



        public async Task<IEnumerable<DevicePort>> GetPortsByDeviceAsync(Guid deviceId, bool activeOnly)
        {
            var query = _context.DevicePorts.AsQueryable().Where(p => p.DeviceId == deviceId);
            if (activeOnly)
                query = query.Where(p => p.IsActive);
            return await query.ToListAsync();
        }

        public async Task ReplacePortSetAsync(Guid deviceId)
        {
            // Mark old ports inactive
            var existingPorts = await _context.DevicePorts
                .Where(p => p.DeviceId == deviceId && p.IsActive)
                .ToListAsync();

            existingPorts.ForEach(p => p.IsActive = false);
            _context.DevicePorts.UpdateRange(existingPorts);

            // Find new version
            int newVersion = (await _context.DevicePorts
                .Where(p => p.DeviceId == deviceId)
                .MaxAsync(p => (int?)p.PortSetVersion)) ?? 1;

            await _context.SaveChangesAsync();

            // Create new port set
            await CreateDefaultPortsForDevice(deviceId, newVersion + 1);
        }

        public async Task CreateDefaultPortsForDevice(Guid deviceId, int version)
        {
            var ports = Enumerable.Range(0, 8).Select(portNum => new DevicePort
            {
                DeviceId = deviceId,
                PortNumber = portNum,
                Signal = $"Signal_{portNum}",
                Register = $"4000{portNum + 1}",
                PortSetVersion = version,
                IsActive = true
            }).ToList();

            _context.DevicePorts.AddRange(ports);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Device>> AddFromFile(Stream csvfile)
        {
            try
            {
                using var reader = new StreamReader(csvfile);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var dtoList = csv.GetRecords<DeviceDto>().ToList();

                var importedDeviced = dtoList.Select(x => new Device
                {
                    DeviceId = new Guid(),
                    Description = x.Description,
                    Name = x.Name,
                    Protocol = x.Protocol
                }).ToList();

                await _repo.AddInDatabase(importedDeviced);

                return importedDeviced;
            }
            catch (CsvHelperException csvEx)
            {
                throw new ApplicationException("CSV format is invalid", csvEx);
            }
            catch (DbUpdateException dbEx)
            {
                throw new ApplicationException("Database error while saving devices", dbEx);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unexpected error during import", ex);
            }
        } 
    }
}
