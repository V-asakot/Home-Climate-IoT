using MediatR;

namespace RoomsClimate.Service.Features.SetThermostat
{
    public record SetThermostatCommand(Guid DeviceGuid, float ThermostatValue) : IRequest<bool>;
}