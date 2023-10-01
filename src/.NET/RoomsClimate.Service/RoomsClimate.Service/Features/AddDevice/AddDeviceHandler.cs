using MediatR;
using RoomsClimate.Service.Data;
using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data.Entities;

namespace RoomsClimate.Service.Features.AddDevice
{
    public class AddDeviceHandler : IRequestHandler<AddDeviceCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddDeviceHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddDeviceCommand command, CancellationToken cancellationToken)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomGuid == command.RoomGuid);
            if (room is null)
            {
                return false;
            }

            var device = new Device()
            {
                DeviceGuid = command.DeviceGuid,
                RoomId = room.Id,
                DeviceName = command.DeviceName,    
                DeviceType = command.DeviceType,
                IsActive = true
            };
            
            await _dbContext.Devices.AddAsync(device);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}