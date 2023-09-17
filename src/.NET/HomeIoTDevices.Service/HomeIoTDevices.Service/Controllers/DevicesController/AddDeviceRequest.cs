using HomeIoT.Contracts.Enums;

namespace HomeIoTDevices.Service.Controllers.DevicesController
{
    public class AddDeviceRequest
    {
        public Guid RoomGuid { get; set; }
        public string DeviceName { get; set; } = null!;
        public DeviceType DeviceType { get; set; }
    }
}
