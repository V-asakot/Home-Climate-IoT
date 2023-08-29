using Mapster;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RoomsClimate.Service.Data;
using RoomsClimate.Service.Data.Entities;
using RoomsClimate.Service.Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RoomsClimate.Service.Features.SaveClimateMeasurment
{
    public class SaveClimateMeasurmentHandler : IRequestHandler<SaveClimateMeasurmentCommand>
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

        public async Task Handle(SaveClimateMeasurmentCommand command, CancellationToken cancellationToken)
        {
            var measurment = command.Adapt<ClimateMeasurment>();
            await _dbContext.Measurments.AddAsync(measurment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var cacheKey = CacheUtils.FormCacheKey(_lastMeasurmentCacheKey, command.RoomId);
            _cache.Set(cacheKey, measurment);
        }
    }
}
