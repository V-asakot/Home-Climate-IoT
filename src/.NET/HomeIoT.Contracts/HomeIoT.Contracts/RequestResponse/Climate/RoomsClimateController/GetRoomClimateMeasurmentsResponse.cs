using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Contracts.RequestResponse.Climate.RoomsClimateController
{
    public record RoomClimateMeasurment(Guid DeviceGuid, float Temperature, float Humidity, DateTime MeasurmentTime);
    public record GetRoomClimateMeasurmentsResponse(IEnumerable<RoomClimateMeasurment> Measurments);
}