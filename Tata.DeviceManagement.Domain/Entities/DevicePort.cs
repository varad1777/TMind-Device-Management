using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tata.DeviceManagement.Domain.Entities
{
    
        public class DevicePort
        {
            public Guid Id { get; set; } = new Guid();
        public Guid DeviceId { get; set; }
            public int PortNumber { get; set; }
            public string? Signal { get; set; }
            public string? Register { get; set; }
            public int PortSetVersion { get; set; } = 1;
            public bool IsActive { get; set; } = true;
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public Device Device { get; set; } = null!;
        
    }

}
