using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;

namespace RoomsClimate.Service.Features.GetRoomThermostats
{
    public record GetRoomThermostatsResult(IEnumerable<ThermostatSettingsDto> ThermostatsSettings);
}