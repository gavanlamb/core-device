using Core.Device.Api.Models.Enum;

namespace Core.Device.Api.Models.DTO
{
    public class Device
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public ThingType ThingTypes { get; set; }
    }
}