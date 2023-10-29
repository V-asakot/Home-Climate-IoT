public static class Endpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/measurments/{deviceGuid}",  async (Guid deviceGuid,  ClimateService climateService) => 
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

        app.MapGet("api/rooms/{roomGuid}", async (Guid roomGuid) =>
        {
            //var res = await climateService.GetRoomMeasurments(roomGuid);
            //return res;
        })
        .WithName("Get room")
        .WithOpenApi();
    }
}