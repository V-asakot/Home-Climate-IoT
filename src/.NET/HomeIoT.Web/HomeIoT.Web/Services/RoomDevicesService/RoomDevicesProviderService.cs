using HomeIoT.Web.Services.DevicesDataProviders;
using HomeIoT.Web.Shared.Component;
using System.Linq;

namespace HomeIoT.Web.Services.RoomDevicesService
{
    public class RoomDevicesProviderService
    {
        private readonly IEnumerable<DevicesDataProvider> _devicesDataProviders;
        public RoomDevicesProviderService(IEnumerable<DevicesDataProvider> devicesDataProviders) 
        {
            _devicesDataProviders = devicesDataProviders;
        }

        public async Task<List<CardMetadata>> GetRoomDevices(Guid roomGuid) 
        {
            var result = new List<CardMetadata>();

            foreach (var deviceDataProvider in _devicesDataProviders)
            {
                var devices = await deviceDataProvider.GetRoomDevices(roomGuid);
                result.AddRange(devices);
            }

            return result;
        }
    }
}
