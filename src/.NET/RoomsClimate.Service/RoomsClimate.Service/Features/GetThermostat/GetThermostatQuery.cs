using MediatR;

namespace RoomsClimate.Service.Features.GetThermostat
{
    public record GetThermostatQuery(Guid DeviceGuid) : IRequest<GetThermostatResult?>;
}