using HomeIoT.Contracts.Events.Devices;
using MassTransit;

namespace RoomsClimate.Service.Consumers.DeviceAdded
{
    public class DeviceAddedEventConsumer : IConsumer<DeviceAddedEvent>
    {
        public Task Consume(ConsumeContext<DeviceAddedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
