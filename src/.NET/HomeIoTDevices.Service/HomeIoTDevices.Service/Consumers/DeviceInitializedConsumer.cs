using HomeIoT.Contracts.Events.Devices;
using HomeIoTDevices.Service.Features.InitializeDevice;
using MassTransit;
using MediatR;


namespace HomeIoTDevices.Service.Consumers.DeviceInitializedConsumer
{
    public class DeviceInitializedConsumer : IConsumer<DeviceInitializedEvent>
    {
        private readonly ILogger<DeviceInitializedConsumer> _logger;
        private readonly IMediator _mediator;
        public DeviceInitializedConsumer(ILogger<DeviceInitializedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<DeviceInitializedEvent> context)
        {
            var message = context.Message;

            var addDeviceCommand = new InitializeDeviceCommand(
                message.RoomGuid,
                message.DeviceGuid,
                message.DeviceName,
                message.DeviceType);

            await _mediator.Send(addDeviceCommand);
        }
    }
}