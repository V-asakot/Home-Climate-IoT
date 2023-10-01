using HomeIoT.Contracts.Enums;

namespace IoT.Contracts.RequestResponse.Devices.DevicesController
{
    public record AddDeviceRequest(Guid RoomGuid, string DeviceName, DeviceType DeviceType);
    
}