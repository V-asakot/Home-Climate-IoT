using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace RoomsClimate.Service.Features.GetThermostat
{
    public class GetThermostatHandler : IRequestHandler<GetThermostatQuery, GetThermostatResult?>
    {
        private readonly Data.ApplicationDbContext _dbContext;
        public GetThermostatHandler(Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetThermostatResult?> Handle(GetThermostatQuery querry, CancellationToken cancellationToken)
        {
            var thermostat = await _dbContext.ThermostatsSettings
            .FirstOrDefaultAsync(x => x.Device != null && x.Device.DeviceGuid == querry.DeviceGuid);

            if(thermostat is null)
            {
                return null;           
            }

            var thermostatSettings = new ThermostatSettingsDto(thermostat.Device.DeviceGuid, thermostat.ThermostatValue);
            return new GetThermostatResult(thermostatSettings);
        }
    }
}