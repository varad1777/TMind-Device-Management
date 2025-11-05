using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tata.DeviceManagement.Domain.Enums;

namespace Tata.DeviceManagement.Domain.Entities
{
    public class Device
    {
        public Guid DeviceId { get; set; }
        public string Description { get; set; } = "";
        public string Name { get; set; } = string.Empty;
        public string Protocol { get; set; } = string.Empty;
        public DeviceStatus status { get; set; }
        public int? ConfigurationId { get; set; }
        public DeviceConfiguration? Configuration { get; set; } = null!;
        public ICollection<DevicePort>? Ports { get; set; } = new List<DevicePort>();
    }
}
