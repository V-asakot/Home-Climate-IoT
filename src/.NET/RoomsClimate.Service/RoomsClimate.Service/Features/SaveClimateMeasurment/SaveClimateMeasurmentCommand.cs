using MediatR;

namespace RoomsClimate.Service.Features.SaveClimateMeasurment
{
    public record SaveClimateMeasurmentCommand(int RoomId, float Temperature, float Humidity, DateTime MeasurmentTime) : IRequest;
}