using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data;

namespace RoomsClimate.Service.Controllers.RoomsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomsController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet()]
        public async Task<GetRoomsResponse> GetRooms()
        {
            var rooms = await _dbContext.Rooms.Where(x => x.IsActive).ToArrayAsync();
            return new GetRoomsResponse(rooms);
        }
    }
}
