using HomeIoT.Contracts.Events.Devices;
using MassTransit;

namespace RoomsClimate.Service.Consumers.RoomAdded
{
    public class RoomAddedEventConsumer : IConsumer<RoomAddedEvent>
    {
        public Task Consume(ConsumeContext<RoomAddedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
