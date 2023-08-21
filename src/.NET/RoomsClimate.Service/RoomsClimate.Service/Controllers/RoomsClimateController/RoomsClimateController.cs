using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoomsClimate.Service.Controllers.RoomsClimateController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomClimateController : ControllerBase
    {
        [HttpGet("{roomId}")]
        public async Task<GetClimateMeasurmentResponse> GetClimateMeasurment(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
