using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tata.DeviceManagement.Domain.Entities
{
    public class DevicePort
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; } = null!;
        public int PortNumber { get; set; }
        public string SignalType { get; set; } = string.Empty;
        public string RegisterAddress { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
