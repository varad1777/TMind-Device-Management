using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tata.DeviceManagement.Application.DTOs
{
    public class DeviceDto
    {
      

        public string Description { get; set; } = "";

        public string Name { get; set; } = "";
        public string Protocol { get; set; } = "";
        public string Status { get; set; } = "";
    }
    public class DeviceDtoForUpdate
    {
      

        public Guid DeviceId { get; set; }
        public string Description { get; set; } = "";

        public string Name { get; set; } = "";
        public string Protocol { get; set; } = "";
        public string Status { get; set; } = "";
    }

    public class CreateDeviceRequest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Protocol { get; set; } = "";
        public string ConnectionType { get; set; } = "";
        public Guid ConfigurationId { get; set; }
    }
}
