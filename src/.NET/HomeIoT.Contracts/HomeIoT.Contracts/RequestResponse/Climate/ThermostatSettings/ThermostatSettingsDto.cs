namespace IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController
{
    public record ThermostatSettingsDto(Guid DeviceGuid, float ThermostatValue);
}
