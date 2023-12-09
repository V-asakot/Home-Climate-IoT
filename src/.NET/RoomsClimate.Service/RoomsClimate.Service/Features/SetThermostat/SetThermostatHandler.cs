using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data;

namespace RoomsClimate.Service.Features.SetThermostat
{
    public class SetThermostatHandler : IRequestHandler<SetThermostatCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;
        public SetThermostatHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(SetThermostatCommand command, CancellationToken cancellationToken)
        {
            var thermostat = await _dbContext.ThermostatsSettings
            .FirstOrDefaultAsync(x => x.Device != null && x.Device.DeviceGuid == command.DeviceGuid);

            if(thermostat is null)
            {
                return false;           
            }

            thermostat.ThermostatValue = command.ThermostatValue;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}