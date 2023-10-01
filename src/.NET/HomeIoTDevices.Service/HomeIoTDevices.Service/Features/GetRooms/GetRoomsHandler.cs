using HomeIoTDevices.Service.Data;
using IoT.Contracts.RequestResponse.Devices.RoomsController;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeIoTDevices.Service.Features.GetRooms
{
    public class GetRoomsHandler : IRequestHandler<GetRoomsQuery, GetRoomsResult?>
    {

        private readonly ApplicationDbContext _dbContext;
        public GetRoomsHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetRoomsResult?> Handle(GetRoomsQuery query, CancellationToken cancellationToken)
        {
            var rooms = await _dbContext.Rooms
                .Select(x => new RoomDto(x.RoomGuid,x.RoomName))
                .ToArrayAsync();
            return new GetRoomsResult(rooms);
        }
    }
}