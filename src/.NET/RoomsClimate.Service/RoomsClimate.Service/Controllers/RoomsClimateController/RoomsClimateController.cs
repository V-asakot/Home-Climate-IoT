using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsClimate.Service.Features.GetClimateMeasurment;
using MediatR;
using Mapster;

namespace RoomsClimate.Service.Controllers.RoomsClimateController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomClimateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomClimateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{roomId}")]
        public async Task<GetClimateMeasurmentResponse> GetClimateMeasurment(int roomId, CancellationToken cancellationToken)
        {
            var querry = new GetClimateMeasurmentQuerry(roomId);
            var climateMeasurment = await _mediator.Send(querry, cancellationToken);

            var result = climateMeasurment.Adapt<GetClimateMeasurmentResponse>();
            return result;
        }
    }
}
