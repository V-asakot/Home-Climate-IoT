using HomeIoT.Contracts.Events.Devices;
using Mapster;
using MassTransit;
using MediatR;
using RoomsClimate.Service.Features.AddRoom;

namespace RoomsClimate.Service.Consumers.RoomAdded
{
    public class RoomAddedEventConsumer : IConsumer<RoomAddedEvent>
    {
        private readonly IMediator _mediator;
        public RoomAddedEventConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<RoomAddedEvent> context)
        {
            var message = context.Message;
            var addRoomCommand = message.Adapt<AddRoomCommand>();
            await _mediator.Send(addRoomCommand);
        }
    }
}
