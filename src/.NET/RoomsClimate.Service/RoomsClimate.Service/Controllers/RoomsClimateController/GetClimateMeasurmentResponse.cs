using System.ComponentModel.DataAnnotations;

namespace RoomsClimate.Service.Controllers.RoomsClimateController
{
    public class GetClimateMeasurmentResponse
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime MeasurmentTime { get; set; }
    }
}
