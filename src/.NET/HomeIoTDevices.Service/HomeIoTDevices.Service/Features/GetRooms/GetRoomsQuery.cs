using MediatR;

namespace HomeIoTDevices.Service.Features.GetRooms
{
    public record GetRoomsQuery() : IRequest<GetRoomsResult>;
}
