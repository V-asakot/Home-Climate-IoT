using HomeIoT.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeIoT.Contracts.Events.Devices
{
    public record DeviceAddedEvent(string DeviceName, Guid DeviceGuid, DeviceType DeviceType);
}
