using MediatR;

namespace HomeIoTDevices.Service.Features.GetRoomDevices
{
    public record GetRoomDevicesQuery(Guid RoomGuid) : IRequest<GetRoomDevicesResult>;
}
