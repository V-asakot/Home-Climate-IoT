using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsClimate.Service.Data.Entities
{
    public class ThermostatSettings : BaseEntity
    {
        //note: global unique identifier across services
        [ForeignKey("DeviceGuid")]
        public Device? Device { get; set; }
        public string ThermostatName { get; set; } = null!;
        public float ThermostatValue { get; set; }
        public bool IsActive { get; set; }
    }
}