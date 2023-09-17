using HomeIoT.Contracts.Enums;

namespace HomeIoTDevices.Service.Data.Dto
{
    public class DeviceDto
    {
        public Guid DeviceGuid { get; set; }
        public string DeviceName { get; set; } = null!;
        public DeviceType DeviceType { get; set; }
        public bool IsActive { get; set; }
    }
}
