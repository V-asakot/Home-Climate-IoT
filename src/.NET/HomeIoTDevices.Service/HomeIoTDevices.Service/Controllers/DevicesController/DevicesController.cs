using HomeIoTDevices.Service.Features.AddDevice;
using HomeIoTDevices.Service.Features.GetRoomDevices;
using IoT.Contracts.RequestResponse.Devices.DevicesController;
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
        public async Task<ActionResult<DeviceDto>> AddDevice([FromBody] AddDeviceRequest addDeviceRequest)
        {
            var addDeviceCommand = new AddDeviceCommand(
                addDeviceRequest.RoomGuid,
                addDeviceRequest.DeviceName,
                addDeviceRequest.DeviceType);

            var addDeviceResult = await _mediator.Send(addDeviceCommand);
            var addDeviceResponse = addDeviceResult?.Adapt<DeviceDto>();
            return addDeviceResponse != null ? Ok(addDeviceResponse) : BadRequest();
        }

        [HttpGet("{roomGuid}")]
        public async Task<ActionResult<GetDevicesResponse>> GetRoomDevices(Guid roomGuid)
        {
            var addDeviceCommand = new GetRoomDevicesQuery(roomGuid);

            var addDeviceResult = await _mediator.Send(addDeviceCommand);
            var getDevicesResponse = addDeviceResult.Adapt<GetDevicesResponse>();
            return getDevicesResponse != null ? Ok(getDevicesResponse) : BadRequest();
        }
    }
}
