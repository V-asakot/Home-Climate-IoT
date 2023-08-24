using Mapster;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RoomsClimate.Service.Data;
using RoomsClimate.Service.Data.Entities;

namespace RoomsClimate.Service.Features.SaveClimateMeasurment
{
    public class SaveClimateMeasurmentHandler : IRequestHandler<SaveClimateMeasurmentCommand>
    {
        private readonly IDistributedCache _cache;
        private readonly ApplicationDbContext _dbContext;
        private readonly string _lastMeasurmentCacheKey;
        public SaveClimateMeasurmentHandler(IDistributedCache cache, 
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

            string json = JsonConvert.SerializeObject(measurment);
            await _cache.SetStringAsync(_lastMeasurmentCacheKey, json, cancellationToken);
        }
    }
}
