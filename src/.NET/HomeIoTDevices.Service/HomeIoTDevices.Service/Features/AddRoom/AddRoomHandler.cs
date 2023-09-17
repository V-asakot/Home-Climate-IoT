using HomeIoT.Contracts.Events.Devices;
using HomeIoTDevices.Service.Data;
using HomeIoTDevices.Service.Data.Entities;
using HomeIoTDevices.Service.Features.AddDevice;
using MassTransit;
using MediatR;

namespace HomeIoTDevices.Service.Features.AddRoom
{
    public class AddRoomHandler : IRequestHandler<AddRoomCommand, AddRoomResult?>
    {
        private readonly ApplicationDbContext _dbContext;
        public readonly IBus _bus;
        public AddRoomHandler(ApplicationDbContext dbContext, IBus bus)
        {
            _dbContext = dbContext;
            _bus = bus;
        }

        public async Task<AddRoomResult?> Handle(AddRoomCommand command, CancellationToken cancellationToken)
        {
            var room = new Room(command.roomName);
            await _dbContext.Rooms.AddAsync(room, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _bus.Publish<RoomAddedEvent>(new(room.RoomName, room.RoomGuid));

            return new AddRoomResult(room.RoomGuid);
        }
    }
}
