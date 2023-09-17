using HomeIoTDevices.Service.Features.AddRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeIoTDevices.Service.Controllers.RoomsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IMediator _mediator;
        public RoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("{roomName}")]
        public async Task<ActionResult<Guid>> AddRoom(string roomName)
        {
            var addDeviceCommand = new AddRoomCommand(roomName);
            var addDeviceResult = await _mediator.Send(addDeviceCommand);
            return addDeviceResult != null ? Ok(addDeviceResult.RoomGuid) : BadRequest();
        }
    }
}
