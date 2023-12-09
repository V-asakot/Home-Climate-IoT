using IoT.Contracts.RequestResponse.Climate.RoomsClimateController;
using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;

public class ClimateService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ClimateService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetClimateMeasurmentResponse?> GetDeviceMeasurments(Guid deviceGuid){
        var client = _httpClientFactory.CreateClient("roomClimate");
        var res = await client.GetFromJsonAsync<GetClimateMeasurmentResponse>($"api/measurments/{deviceGuid}");
        return res;
    }

    public async Task<GetRoomClimateMeasurmentsResponse?> GetRoomMeasurments(Guid roomGuid){
        var client = _httpClientFactory.CreateClient("roomClimate");
        var res = await client.GetFromJsonAsync<GetRoomClimateMeasurmentsResponse>($"api/measurments/room/{roomGuid}");
        return res;
    }

    public async Task<GetRoomThermostatsResponse?> GetRoomThermostats(Guid roomGuid){
        var client = _httpClientFactory.CreateClient("roomClimate");
        var res = await client.GetFromJsonAsync<GetRoomThermostatsResponse>($"api/thermostats/room/{roomGuid}");
        return res;
    }

    public async Task<SetThermostatResponse?> SetThermostatSettings(SetThermostatRequest setThermostatRequest){
        var client = _httpClientFactory.CreateClient("roomClimate");
        var setThermostatResponse = await client.PostAsJsonAsync($"api/thermostats", setThermostatRequest);
        var res = await setThermostatResponse.Content.ReadFromJsonAsync<SetThermostatResponse>();
        return res;
    }
}