using HomeIoT.Web.Shared;
using HomeIoT.Web.Shared.Component;
using HomeIoT.Web.Utils;
using IoT.Contracts.RequestResponse.Climate.RoomsClimateController;
using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;
using System.Diagnostics.Metrics;
using System.Net.Http.Json;

namespace HomeIoT.Web.Services.DevicesDataProviders
{
    public class ThermostatsDataProvider : DevicesDataProvider
    {
        public ThermostatsDataProvider(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async override Task<List<CardMetadata>> GetRoomDevices(Guid roomGuid)
        {
            var measurments = await GetDevicesStates<GetRoomThermostatsResponse>($"api/thermostats/room/{roomGuid}");
            var components = measurments.ThermostatsSettings.ConvertToCardMetadata<ThermostatSettingsDto,ThermostatCard>();
            return components;
        }
    }
}
