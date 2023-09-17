using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsClimate.Service.Data.Entities
{
    public class ClimateMeasurment : BaseEntity
    {
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public Device Device { get; set; } = null!;
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime MeasurmentTime { get; set; }

        public ClimateMeasurment(int deviceId, float temperature, float humidity, DateTime measurmentTime)
        {
            DeviceId = deviceId;
            Temperature = temperature;
            Humidity = humidity;
            MeasurmentTime = measurmentTime;
        }
    }
}
