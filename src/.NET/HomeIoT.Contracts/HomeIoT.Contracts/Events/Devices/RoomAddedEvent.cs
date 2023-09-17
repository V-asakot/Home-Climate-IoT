using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeIoT.Contracts.Events.Devices
{
    public record RoomAddedEvent(string RoomName, Guid RoomGuid);
}
