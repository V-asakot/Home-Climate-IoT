using HomeIoTDevices.Service.Data.Dto;

namespace HomeIoTDevices.Service.Controllers.DevicesController
{
    public class GetDevicesResponse
    {
        public IEnumerable<DeviceDto> Devices { get; set; } = null!;
    }
}
