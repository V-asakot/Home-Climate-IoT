using HomeIoTDevices.Service.Features.AddDevice;
using MediatR;

namespace HomeIoTDevices.Service.Features.AddRoom
{
    public record AddRoomCommand(string roomName) : IRequest<AddRoomResult?>;
}
