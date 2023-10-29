using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;

namespace RoomsClimate.Service.Features.GetThermostat
{
    public record GetThermostatResult(ThermostatSettingsDto ThermostatSettings);
}