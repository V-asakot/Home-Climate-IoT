using MediatR;

namespace RoomsClimate.Service.Features.GetRoomThermostats
{
    public record GetRoomThermostatsQuery(Guid RoomGuid) : IRequest<GetRoomThermostatsResult?>;
}