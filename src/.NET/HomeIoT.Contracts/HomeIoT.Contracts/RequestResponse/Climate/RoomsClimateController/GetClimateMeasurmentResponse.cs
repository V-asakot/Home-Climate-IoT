using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Contracts.RequestResponse.Climate.RoomsClimateController
{
    public class GetClimateMeasurmentResponse
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime MeasurmentTime { get; set; }
    }
}
