using Iot.Common.Events.Climate;
using Mapster;
using MassTransit;
using MediatR;
using RoomsClimate.Service.Features.SaveClimateMeasurment;

namespace RoomsClimate.Service.Consumers.ClimateMeasured
{
    public class ClimateMeasuredConsumer : IConsumer<ClimateMeasuredEvent>
    {
        private readonly ILogger<ClimateMeasuredConsumer> _logger;
        private readonly IMediator _mediator;
        public ClimateMeasuredConsumer(ILogger<ClimateMeasuredConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ClimateMeasuredEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Measurment received RoomId:{message.RoomId} DateTime:{message.MeasurmentTime} Temperature:{message.Temperature} Humidity:{message.Humidity}");
            
            var command = message.Adapt<SaveClimateMeasurmentCommand>();
            await _mediator.Send(command);
        }
    }
}
