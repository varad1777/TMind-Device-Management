using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tata.DeviceManagement.Domain.Enums
{
    public enum DeviceStatus
    {
        Offline = 0,    // Device is not connected
        Online = 1,     // Device is connected and working
        Error = 2,
    }
}
