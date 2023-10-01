using HomeIoT.Contracts.Events.Devices;
using MassTransit;
using Mapster;
using MediatR;
using RoomsClimate.Service.Features.AddDevice;

namespace RoomsClimate.Service.Consumers.DeviceAdded
{
    public class DeviceAddedEventConsumer : IConsumer<DeviceAddedEvent>
    {
        private readonly IMediator _mediator;
        public DeviceAddedEventConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<DeviceAddedEvent> context)
        {
            var message = context.Message;
            var addDeviceCommand = message.Adapt<AddDeviceCommand>();
            await _mediator.Send(addDeviceCommand);
        }
    }
}
