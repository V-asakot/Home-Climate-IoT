using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data;

namespace RoomsClimate.Service.Features.GetRoomThermostats
{
    public class GetRoomThermostatsHandler : IRequestHandler<GetRoomThermostatsQuery, GetRoomThermostatsResult>
    {
         private readonly ApplicationDbContext _dbContext;
        public GetRoomThermostatsHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetRoomThermostatsResult> Handle(GetRoomThermostatsQuery querry, CancellationToken cancellationToken)
        {
            var thermostats = await _dbContext.ThermostatsSettings
            .Where(x => x.Device != null && x.Device.Room.RoomGuid == querry.RoomGuid)
            .Select(x => 
            new ThermostatSettingsDto(x!.Device.DeviceGuid, x.ThermostatValue)
            {
                DeviceGuid = x.Device.DeviceGuid,
                ThermostatValue = x.ThermostatValue
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

            var getRoomThermostatsResult = new GetRoomThermostatsResult(thermostats);
            return getRoomThermostatsResult;
        }
    }
}