using IoT.Contracts.RequestResponse.Climate.ThermostatsSettingsController;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomsClimate.Service.Features.GetRoomClimateMeasurment;
using RoomsClimate.Service.Features.GetRoomThermostats;
using RoomsClimate.Service.Features.GetThermostat;
using RoomsClimate.Service.Features.SetThermostat;

namespace RoomsClimate.Service.Controllers.ThermostatSettingsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThermostatSettingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ThermostatSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("room/{roomGuid}")]
        public async Task<ActionResult<GetRoomThermostatsResponse>> GetRoomThermostats(Guid roomGuid, CancellationToken cancellationToken)
        {
            var querry = new GetRoomThermostatsQuery(roomGuid);
            var thermostats = await _mediator.Send(querry, cancellationToken);

            if (thermostats is null)
            {
                return NotFound();
            }

            var getRoomThermostatsResponse = thermostats.Adapt<GetRoomThermostatsResponse>();
            return Ok(getRoomThermostatsResponse);
        }

        [HttpGet("{deviceGuid}")]
        public async Task<ActionResult<GetThermostatResponse>> GetThermostat(Guid deviceGuid, CancellationToken cancellationToken)
        {
            var querry = new GetThermostatQuery(deviceGuid);
            var thermostat = await _mediator.Send(querry, cancellationToken);

            if (thermostat is null)
            {
                return NotFound();
            }

            var getThermostatResponse = thermostat.Adapt<GetThermostatResponse>();
            return Ok(getThermostatResponse);
        }

        [HttpPost]
        public async Task<ActionResult<SetThermostatResponse>> SetThermostat(SetThermostatRequest request, CancellationToken cancellationToken)
        {
            var command = new SetThermostatCommand(request.ThermostatSettings.DeviceGuid, 
                request.ThermostatSettings.ThermostatValue);

            var result = await _mediator.Send(command, cancellationToken);
            var setThermostatResponse = new SetThermostatResponse(result);
            return Ok(setThermostatResponse);
        }
    }
}
