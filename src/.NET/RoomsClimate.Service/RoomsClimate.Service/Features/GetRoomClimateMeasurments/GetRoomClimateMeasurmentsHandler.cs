using IoT.Contracts.RequestResponse.Climate.RoomsClimateController;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RoomsClimate.Service.Data;
using RoomsClimate.Service.Data.Entities;
using RoomsClimate.Service.Features.GetRoomClimateMeasurment;
using RoomsClimate.Service.Utils;

namespace RoomsClimate.Service.Features.GetRoomClimateMeasurment
{
    public class GetRoomClimateMeasurmentHandler : IRequestHandler<GetRoomClimateMeasurmentsQuery, GetRoomClimateMeasurmentsResult?>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetRoomClimateMeasurmentHandler(IMemoryCache cache,
            ApplicationDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<GetRoomClimateMeasurmentsResult?> Handle(GetRoomClimateMeasurmentsQuery querry, CancellationToken cancellationToken)
        {
            var room = await _dbContext.Rooms
                .FirstOrDefaultAsync(x => x.RoomGuid == querry.RoomGuid);

            if(room is null)
            {
                return null;
            }

            var res = await _dbContext.Measurments
                .Where(x => x.Device.RoomId == room.Id)
                .Include(x => x.Device)
                .GroupBy(x => x.DeviceId)               
                .Select(g => g.OrderByDescending(c=>c.Id).FirstOrDefault())
                .ToListAsync(cancellationToken: cancellationToken);
            
            var measurments = res.Select(x => new RoomClimateMeasurment(
                x!.Device.DeviceGuid, 
                x.Temperature, 
                x.Humidity, 
                x.MeasurmentTime));

            if(measurments is null)
            {
                return null;
            }

            return new GetRoomClimateMeasurmentsResult(measurments);
        }
    }
}