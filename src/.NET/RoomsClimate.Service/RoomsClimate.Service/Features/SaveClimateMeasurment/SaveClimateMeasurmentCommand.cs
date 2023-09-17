using MediatR;

namespace RoomsClimate.Service.Features.SaveClimateMeasurment
{
    public record SaveClimateMeasurmentCommand(Guid DeviceGuid, float Temperature, float Humidity, DateTime MeasurmentTime) : IRequest<bool>;
}