using HomeIoT.Contracts.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeIoTDevices.Service.Data.Entities
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

        public Device(int roomId, string deviceName, DeviceType deviceType)
        {
            DeviceGuid = Guid.NewGuid();
            RoomId = roomId;
            DeviceName = deviceName;
            DeviceType = deviceType;
            IsActive = true;
        }

        public Device(int roomId, string deviceName, DeviceType deviceType,Guid deviceGuid)
        {
            DeviceGuid = deviceGuid;
            RoomId = roomId;
            DeviceName = deviceName;
            DeviceType = deviceType;
            IsActive = true;
        }
    }
}
