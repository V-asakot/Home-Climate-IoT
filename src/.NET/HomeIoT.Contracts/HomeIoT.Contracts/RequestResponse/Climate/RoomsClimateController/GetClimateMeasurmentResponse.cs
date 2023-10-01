using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Contracts.RequestResponse.Climate.RoomsClimateController
{
    public record GetClimateMeasurmentResponse(float Temperature, float Humidity, DateTime MeasurmentTime);
}
