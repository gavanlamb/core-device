using Core.Device.Api.Models.Enum;

namespace Core.Device.Api.Models.Domain
{
    public class SensorValue
    {
        public string Name { get; set; }

        public SensorValueType Type { get; set; }

        public object Default { get; set; }
    }
}