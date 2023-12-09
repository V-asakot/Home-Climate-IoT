using HomeIoT.Web.Shared;
using HomeIoT.Web.Shared.Component;
using HomeIoT.Web.Utils;
using IoT.Contracts.RequestResponse.Climate.RoomsClimateController;
using System.Net.Http.Json;

namespace HomeIoT.Web.Services.DevicesDataProviders
{
    public class ClimateSensorsDataProvider : DevicesDataProvider
    {

        public ClimateSensorsDataProvider(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async override Task<List<CardMetadata>> GetRoomDevices(Guid roomGuid)
        {
            var measurments = await GetDevicesStates<GetRoomClimateMeasurmentsResponse>($"api/measurments/room/{roomGuid}");
            var components = measurments?.Measurments.ConvertToCardMetadata<RoomClimateMeasurment,ClimateMeasurmentsCard>();

            return components;
        }

    }
}
