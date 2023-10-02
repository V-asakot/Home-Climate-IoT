using IoT.Contracts.RequestResponse.Climate.RoomsClimateController;

namespace RoomsClimate.Service.Features.GetRoomClimateMeasurment
{
    public record GetRoomClimateMeasurmentsResult(IEnumerable<RoomClimateMeasurment> Measurments);
}