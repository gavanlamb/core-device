using Core.Devices.Api.Models.Enum;

namespace Core.Devices.Api.Models.DTO
{
    public class UpdateUserDevice
    {
        public string Name { get; set; }

        public DeviceType? Types { get; set; }
    }
}