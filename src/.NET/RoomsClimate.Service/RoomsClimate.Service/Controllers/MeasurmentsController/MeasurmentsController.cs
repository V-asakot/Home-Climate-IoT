using IoT.Contracts.RequestResponse.Climate.RoomsClimateController;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomsClimate.Service.Features.GetClimateMeasurment;
using RoomsClimate.Service.Features.GetRoomClimateMeasurment;

namespace RoomsClimate.Service.Controllers.RoomsClimateController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MeasurmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{deviceGuid}")]
        public async Task<ActionResult<GetClimateMeasurmentResponse>> GetClimateMeasurment(Guid deviceGuid, CancellationToken cancellationToken)
        {
            var querry = new GetClimateMeasurmentQuerry(deviceGuid);
            var climateMeasurment = await _mediator.Send(querry, cancellationToken);

            if (climateMeasurment is null)
            {
                return NotFound();
            }

            var result = climateMeasurment.Adapt<GetClimateMeasurmentResponse>();
            return Ok(result);
        }

        [HttpGet("room/{roomGuid}")]
        public async Task<ActionResult<GetRoomClimateMeasurmentsResponse>> GetClimateMeasurments(Guid roomGuid, CancellationToken cancellationToken)
        {
            var querry = new GetRoomClimateMeasurmentsQuery(roomGuid);
            var getRoomClimateMeasurmentsResult = await _mediator.Send(querry, cancellationToken);

            if (getRoomClimateMeasurmentsResult is null)
            {
                return NotFound();
            }

            var getRoomClimateMeasurmentsResponse = getRoomClimateMeasurmentsResult.Adapt<GetRoomClimateMeasurmentsResponse>();
            return Ok(getRoomClimateMeasurmentsResponse);
        }
    }
}
