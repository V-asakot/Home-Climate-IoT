using MediatR;

namespace RoomsClimate.Service.Features.GetClimateMeasurment
{
    public record GetClimateMeasurmentQuerry(Guid DeviceGuid) : IRequest<GetClimateMeasurmentResult>;
}
