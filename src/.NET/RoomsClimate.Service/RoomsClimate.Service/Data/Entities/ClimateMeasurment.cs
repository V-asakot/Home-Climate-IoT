namespace RoomsClimate.Service.Data.Entities
{
    public class ClimateMeasurment : BaseEntity
    {
        public int RoomId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime MeasurmentTime { get; set; }
    }
}
