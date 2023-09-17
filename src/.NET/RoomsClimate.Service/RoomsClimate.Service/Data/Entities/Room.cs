namespace RoomsClimate.Service.Data.Entities
{
    public class Room : BaseEntity
    {
        //note: global unique identifier across services
        public Guid RoomGuid { get; set; }
        public string RoomName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
