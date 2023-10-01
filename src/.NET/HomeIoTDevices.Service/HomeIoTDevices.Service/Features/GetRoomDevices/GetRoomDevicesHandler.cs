using HomeIoTDevices.Service.Data;
using IoT.Contracts.RequestResponse.Devices.DevicesController;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeIoTDevices.Service.Features.GetRoomDevices
{
    public class GetRoomDevicesHandler : IRequestHandler<GetRoomDevicesQuery, GetRoomDevicesResult?>
    {

        private readonly ApplicationDbContext _dbContext;
        public GetRoomDevicesHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetRoomDevicesResult?> Handle(GetRoomDevicesQuery query, CancellationToken cancellationToken)
        {
            var room = await _dbContext.Rooms
                .FirstOrDefaultAsync(x => x.RoomGuid == query.RoomGuid);
            if (room is null)
            {
                return null;
            }

            var devices = await _dbContext.Devices
                .Where(x => x.RoomId == room.Id)
                .Select(x => x.Adapt<DeviceDto>())
                .ToArrayAsync();

            return new GetRoomDevicesResult(devices);
        }
    }
}
