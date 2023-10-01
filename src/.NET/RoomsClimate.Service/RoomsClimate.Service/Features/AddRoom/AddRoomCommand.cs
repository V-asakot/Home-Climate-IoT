using MediatR;

namespace RoomsClimate.Service.Features.AddRoom;

public record AddRoomCommand(Guid RoomGuid, string RoomName) : IRequest<bool>;