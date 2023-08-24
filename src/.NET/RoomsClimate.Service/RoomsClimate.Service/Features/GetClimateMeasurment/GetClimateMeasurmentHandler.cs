using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RoomsClimate.Service.Data;
using RoomsClimate.Service.Features.GetClimateMeasurment;
using RoomsClimate.Service.Features.SaveClimateMeasurment;
using System.Diagnostics.Metrics;

namespace RoomsClimate.Service.Features.GetLastMeasurment
{
    public class GetClimateMeasurmentHandler : IRequestHandler<GetClimateMeasurmentQuerry, GetClimateMeasurmentResult>
    {
        private readonly IDistributedCache _cache;
        private readonly ApplicationDbContext _dbContext;
        private readonly string _lastMeasurmentCacheKey;
        public GetClimateMeasurmentHandler(IDistributedCache cache,
            ApplicationDbContext dbContext,
            IConfiguration configuration)
        {
            _cache = cache;
            _dbContext = dbContext;
            _lastMeasurmentCacheKey = configuration.GetSection("CacheKeys")["LastMeasurmentKey"]!;
        }

        public async Task<GetClimateMeasurmentResult> Handle(GetClimateMeasurmentQuerry querry, CancellationToken cancellationToken)
        {
            var json = await _cache.GetStringAsync(_lastMeasurmentCacheKey, cancellationToken);
            if (json is not null)
            {
                var cachedResult = JsonConvert.DeserializeObject<GetClimateMeasurmentResult>(json);
                return cachedResult!;
            }

            var measurment = await _dbContext.Measurments
                .Where(x => x.Id == querry.RoomId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync(cancellationToken);

            json = JsonConvert.SerializeObject(measurment);
            await _cache.SetStringAsync(_lastMeasurmentCacheKey, json, cancellationToken);

            return new GetClimateMeasurmentResult(measurment.Temperature, measurment.Humidity, measurment.MeasurmentTime);
        }
    }
}
