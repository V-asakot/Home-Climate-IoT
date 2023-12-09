using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;

public static class Endpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/measurments/{deviceGuid}",  async (Guid deviceGuid, ClimateService climateService) => 
        {
            var res = await climateService.GetDeviceMeasurments(deviceGuid);
            return res;
        })
        .WithName("Get device measurments")
        .WithOpenApi();

        app.MapGet("api/measurments/room/{roomGuid}", async (Guid roomGuid, ClimateService climateService) =>
        {
            var res = await climateService.GetRoomMeasurments(roomGuid);
            return res;
        })
        .WithName("Get room measurments")
        .WithOpenApi();

        app.MapGet("api/devices/{roomGuid}", async (Guid roomGuid, DevicesService devicesService) =>
        {
            var res = await devicesService.GetRoomDevices(roomGuid);
            return res;
        })
        .WithName("Get room devices")
        .WithOpenApi();

        app.MapGet("api/rooms", async (DevicesService devicesService) =>
        {
            var res = await devicesService.GetRooms();
            return res;
        })
        .WithName("Get rooms")
        .WithOpenApi();

        app.MapGet("api/thermostats/room/{roomGuid}", async (Guid roomGuid, ClimateService climateService) =>
        {
            var res = await climateService.GetRoomThermostats(roomGuid);
            return res;
        })
        .WithName("Get room thermostats")
        .WithOpenApi();

        app.MapPost("api/thermostats", async (SetThermostatRequest setThermostatRequest, ClimateService climateService) =>
        {
            var res = await climateService.SetThermostatSettings(setThermostatRequest);
            return res;
        })
        .WithName("Set thermostat settings")
        .WithOpenApi();
    }
}