using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RoomsClimate.Service.Data;
using RoomsClimate.Service.Data.Entities;
using RoomsClimate.Service.Features.GetClimateMeasurment;
using RoomsClimate.Service.Features.SaveClimateMeasurment;
using RoomsClimate.Service.Utils;
using System.Diagnostics.Metrics;

namespace RoomsClimate.Service.Features.GetLastMeasurment
{
    public class GetClimateMeasurmentHandler : IRequestHandler<GetClimateMeasurmentQuerry, GetClimateMeasurmentResult>
    {
        private readonly IMemoryCache _cache;
        private readonly ApplicationDbContext _dbContext;
        private readonly string _lastMeasurmentCacheKey;
        public GetClimateMeasurmentHandler(IMemoryCache cache,
            ApplicationDbContext dbContext,
            IConfiguration configuration)
        {
            _cache = cache;
            _dbContext = dbContext;
            _lastMeasurmentCacheKey = configuration.GetSection("CacheKeys")["LastMeasurmentKey"]!;
        }

        public async Task<GetClimateMeasurmentResult> Handle(GetClimateMeasurmentQuerry querry, CancellationToken cancellationToken)
        {
            var cacheKey = CacheUtils.FormCacheKey(_lastMeasurmentCacheKey,querry.RoomId);
            var measurment = _cache.Get<ClimateMeasurment>(cacheKey);
            if (measurment is not null)
            {
                var getClimateMeasurmentResult = new GetClimateMeasurmentResult(measurment.Temperature, measurment.Humidity, measurment.MeasurmentTime);
                return getClimateMeasurmentResult!;
            }

            measurment = await _dbContext.Measurments
                .Where(x => x.Id == querry.RoomId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync(cancellationToken);

            _cache.Set(cacheKey, measurment);

            return new GetClimateMeasurmentResult(measurment.Temperature, measurment.Humidity, measurment.MeasurmentTime);
        }
    }
}
