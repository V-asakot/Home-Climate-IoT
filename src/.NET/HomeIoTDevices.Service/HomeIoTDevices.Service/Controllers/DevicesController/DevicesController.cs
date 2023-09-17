using HomeIoTDevices.Service.Features.AddDevice;
using HomeIoTDevices.Service.Features.GetRoomDevices;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeIoTDevices.Service.Controllers.DevicesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : Controller
    {
        private readonly IMediator _mediator;
        public DevicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddDevice([FromBody] AddDeviceRequest addDeviceRequest)
        {
            var addDeviceCommand = new AddDeviceCommand(
                addDeviceRequest.RoomGuid,
                addDeviceRequest.DeviceName,
                addDeviceRequest.DeviceType);

            var addDeviceResult = await _mediator.Send(addDeviceCommand);
            return addDeviceResult != null ? Ok(addDeviceResult.DeviceGuid) : BadRequest();
        }

        [HttpGet("{roomId}")]
        public async Task<ActionResult<GetDevicesResponse>> GetRoomDevices(Guid roomGuid)
        {
            var addDeviceCommand = new GetRoomDevicesQuery(roomGuid);

            var addDeviceResult = await _mediator.Send(addDeviceCommand);
            var getDevicesResponse = addDeviceResult.Adapt<GetDevicesResponse>();
            return addDeviceResult != null ? Ok() : BadRequest();
        }
    }
}
