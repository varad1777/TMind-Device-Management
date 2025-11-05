<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
=======
﻿
>>>>>>> e6eb3ff698c2c6fb08e8f9b563da5cf46172b475
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

<<<<<<< HEAD
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
=======
        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
>>>>>>> e6eb3ff698c2c6fb08e8f9b563da5cf46172b475
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
<<<<<<< HEAD
        public async Task<bool> DeleteDeviceAsync(Guid id) => await _repo.DeleteAsync(id);

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
=======
>>>>>>> e6eb3ff698c2c6fb08e8f9b563da5cf46172b475
    }
}
