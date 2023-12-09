using MediatR;
using RoomsClimate.Service.Data;
using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data.Entities;

namespace RoomsClimate.Service.Features.AddRoom
{
    public class AddRoomHandler : IRequestHandler<AddRoomCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddRoomHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddRoomCommand command, CancellationToken cancellationToken)
        {
            var room = new Room()
            {
                RoomGuid = command.RoomGuid,
                RoomName = command.RoomName,
                IsActive = true
            };

            if(await _dbContext.Rooms.AnyAsync(x => x.RoomGuid == command.RoomGuid))
            {
                return false;
            }

            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}