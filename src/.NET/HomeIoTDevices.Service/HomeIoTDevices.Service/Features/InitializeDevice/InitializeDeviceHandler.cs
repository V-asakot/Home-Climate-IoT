using HomeIoT.Contracts.Events.Devices;
using HomeIoTDevices.Service.Data;
using HomeIoTDevices.Service.Data.Entities;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeIoTDevices.Service.Features.InitializeDevice
{
    public class InitializeDeviceHandler : IRequestHandler<InitializeDeviceCommand, InitializeDeviceResult?>
    {
        private readonly ApplicationDbContext _dbContext;
        public readonly IBus _bus;
        public InitializeDeviceHandler(ApplicationDbContext dbContext, IBus bus)
        {
            _dbContext = dbContext;
            _bus = bus;
        }

        public async Task<InitializeDeviceResult?> Handle(InitializeDeviceCommand command, CancellationToken cancellationToken)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomGuid == command.RoomGuid);
            if (room is null)
            {
                return null;
            }

            if(await _dbContext.Devices.AnyAsync(x => x.DeviceGuid == command.DeviceGuid))
            {
                return null;
            }

            var device = new Device(room.Id, command.DeviceName, command.DeviceType, command.DeviceGuid);
            await _dbContext.Devices.AddAsync(device, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var deviceAddedEvent = new DeviceAddedEvent(
                device.DeviceName,
                device.DeviceGuid,
                device.Room.RoomGuid,
                device.DeviceType
            );

            await _bus.Publish<DeviceAddedEvent>(deviceAddedEvent);

            return new InitializeDeviceResult(device.DeviceGuid, device.DeviceName, device.DeviceType);
        }
    }
}
