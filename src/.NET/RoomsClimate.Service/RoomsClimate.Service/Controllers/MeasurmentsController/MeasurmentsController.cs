using IoT.Contracts.RequestResponse.Climate.RoomsClimateController;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomsClimate.Service.Features.GetClimateMeasurment;

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
    }
}
