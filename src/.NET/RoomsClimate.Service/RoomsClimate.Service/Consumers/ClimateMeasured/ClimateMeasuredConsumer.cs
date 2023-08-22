using Domain.Events.Climate;
using MassTransit;

namespace RoomsClimate.Service.Consumers.ClimateMeasured
{
    public class ClimateMeasuredConsumer : IConsumer<ClimateMeasuredEvent>
    {
        private readonly ILogger<ClimateMeasuredConsumer> _logger;
        public ClimateMeasuredConsumer(ILogger<ClimateMeasuredConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ClimateMeasuredEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation($"{message.RoomId} {message.MeasurmentTime} {message.Temperature} {message.Humidity}");
        }
    }
}
