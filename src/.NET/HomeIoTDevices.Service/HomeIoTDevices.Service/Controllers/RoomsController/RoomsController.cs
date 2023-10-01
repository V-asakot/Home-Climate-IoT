using HomeIoTDevices.Service.Features.AddDevice;
using HomeIoTDevices.Service.Features.AddRoom;
using HomeIoTDevices.Service.Features.GetRooms;
using IoT.Contracts.RequestResponse.Devices.RoomsController;
using Mapster;
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
        public async Task<ActionResult<RoomDto>> AddRoom(string roomName)
        {
            var addRoomCommand = new AddRoomCommand(roomName);
            var addRoomResult = await _mediator.Send(addRoomCommand);
            var addRoomResponse = addRoomResult?.Adapt<RoomDto>();
            return addRoomResponse != null ? Ok(addRoomResponse) : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<GetRoomsResponse>> GetRooms()
        {
            var getRoomsQuery = new GetRoomsQuery();
            var getRoomsResult = await _mediator.Send(getRoomsQuery);
            var getRoomsResponse = getRoomsResult.Adapt<GetRoomsResponse>();
            return getRoomsResponse != null ? Ok(getRoomsResponse) : BadRequest();
        }
    }
}
