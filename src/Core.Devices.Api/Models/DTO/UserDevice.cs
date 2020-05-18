using Core.Devices.Api.Models.Enum;

namespace Core.Devices.Api.Models.DTO
{
    public class UserDevice
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public DeviceType Types { get; set; }
    }
}