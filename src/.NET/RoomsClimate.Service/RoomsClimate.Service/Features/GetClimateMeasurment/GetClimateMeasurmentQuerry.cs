using MediatR;

namespace RoomsClimate.Service.Features.GetClimateMeasurment
{
    public record GetClimateMeasurmentQuerry(int RoomId) : IRequest<GetClimateMeasurmentResult>;
}
