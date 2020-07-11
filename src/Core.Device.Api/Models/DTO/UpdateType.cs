using System.Collections.Generic;
using Core.Device.Api.Models.Enum;

namespace Core.Device.Api.Models.DTO
{
    public class UpdateType
    {
        public string Name { get; set; }

        public ThingType ThingTypes { get; set; }
        
        public MessageProtocols MessageProtocols { get; set; }
        
        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Image> Icons { get; set; }

        public IEnumerable<ActuatorValue> ActuatorValues { get; set; }

        public IEnumerable<SensorValue> SensorValues { get; set; }
    }
}
