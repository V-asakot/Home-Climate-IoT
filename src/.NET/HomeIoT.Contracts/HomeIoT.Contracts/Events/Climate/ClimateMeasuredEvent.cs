namespace Iot.Common.Events.Climate
{
    public class ClimateMeasuredEvent
    {
        public int RoomId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime MeasurmentTime { get; set; }
    }
}
