using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tata.DeviceManagement.Domain.Entities
{
    public class DeviceConfiguration
    {
        public int Id { get; set; }
        public string BaudRate { get; set; } = "9600";
        public string Parity { get; set; } = "None";
        public string StopBits { get; set; } = "1";
    }
}
