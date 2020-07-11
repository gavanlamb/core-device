using Core.Device.Api.Models.Enum;

namespace Core.Device.Api.Models.DTO
{
    public class ActuatorValue
    {
        public string Name { get; set; }

        public ActuatorValueType Type { get; set; }

        public object Default { get; set; }
    }
}