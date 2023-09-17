using Microsoft.AspNetCore.Mvc;

namespace RoomsClimate.Service.Controllers.RoomsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        [HttpGet]
        public async Task<GetRoomsResponse> GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
