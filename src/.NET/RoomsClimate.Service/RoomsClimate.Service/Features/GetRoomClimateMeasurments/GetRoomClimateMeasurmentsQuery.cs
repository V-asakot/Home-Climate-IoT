using MediatR;

namespace RoomsClimate.Service.Features.GetRoomClimateMeasurment
{
    public record GetRoomClimateMeasurmentsQuery(Guid RoomGuid) : IRequest<GetRoomClimateMeasurmentsResult?>;
}