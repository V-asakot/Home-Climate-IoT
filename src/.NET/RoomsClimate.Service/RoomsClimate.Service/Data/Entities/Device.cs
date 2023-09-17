using HomeIoT.Contracts.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsClimate.Service.Data.Entities
{
    public class Device : BaseEntity
    {
        //note: global unique identifier across services
        public Guid DeviceGuid { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; } = null!;
        public string DeviceName { get; set; } = null!;
        public DeviceType DeviceType { get; set; }
        public bool IsActive { get; set; }
    }
}
