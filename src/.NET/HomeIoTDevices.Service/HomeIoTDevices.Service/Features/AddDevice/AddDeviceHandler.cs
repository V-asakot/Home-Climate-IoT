using HomeIoT.Contracts.Events.Devices;
using HomeIoTDevices.Service.Data;
using HomeIoTDevices.Service.Data.Entities;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeIoTDevices.Service.Features.AddDevice
{
    public class AddDeviceHandler : IRequestHandler<AddDeviceCommand, AddDeviceResult?>
    {
        private readonly ApplicationDbContext _dbContext;
        public readonly IBus _bus;
        public AddDeviceHandler(ApplicationDbContext dbContext, IBus bus)
        {
            _dbContext = dbContext;
            _bus = bus;
        }

        public async Task<AddDeviceResult?> Handle(AddDeviceCommand command, CancellationToken cancellationToken)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomGuid == command.RoomGuid);
            if (room is null)
            {
                return null;
            }

            var device = new Device(room.Id, command.DeviceName, command.DeviceType);
            await _dbContext.Devices.AddAsync(device, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _bus.Publish<DeviceAddedEvent>(new(device.DeviceName, device.DeviceGuid, device.DeviceType));

            return new AddDeviceResult(device.DeviceGuid);
        }
    }
}
