using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RoomsClimate.Service.Data;
using RoomsClimate.Service.Data.Entities;
using RoomsClimate.Service.Utils;

namespace RoomsClimate.Service.Features.SaveClimateMeasurment
{
    public class SaveClimateMeasurmentHandler : IRequestHandler<SaveClimateMeasurmentCommand, bool>
    {
        private readonly IMemoryCache _cache;
        private readonly ApplicationDbContext _dbContext;
        private readonly string _lastMeasurmentCacheKey;
        public SaveClimateMeasurmentHandler(IMemoryCache cache,
            ApplicationDbContext dbContext,
            IConfiguration configuration)
        {
            _cache = cache;
            _dbContext = dbContext;
            _lastMeasurmentCacheKey = configuration.GetSection("CacheKeys")["LastMeasurmentKey"]!;
        }

        public async Task<bool> Handle(SaveClimateMeasurmentCommand command, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices.FirstOrDefaultAsync(x => x.DeviceGuid == command.DeviceGuid);
            if (device is null)
            {
                return false;
            }

            var measurment = new ClimateMeasurment(
                device.Id,
                command.Temperature,
                command.Humidity,
                command.MeasurmentTime);

            await _dbContext.Measurments.AddAsync(measurment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var cacheKey = CacheUtils.FormCacheKey(_lastMeasurmentCacheKey, command.DeviceGuid);
            _cache.Set(cacheKey, measurment);
            return true;
        }
    }
}
