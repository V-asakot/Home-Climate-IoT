namespace IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController
{
    public record GetRoomThermostatsResponse(IEnumerable<ThermostatSettingsDto> ThermostatsSettings);
}
