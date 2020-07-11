using Core.Device.Api.Models.Domain;
using DomainActuatorValue = Core.Device.Api.Models.Domain.ActuatorValue;
using DtoActuatorValue = Core.Device.Api.Models.DTO.ActuatorValue;

namespace Core.Device.Api.Mappers
{
    public static class ActuatorValueMapper
    {
        public static ActuatorValue MapToDomain(
            Models.DTO.ActuatorValue actuatorValue)
        {
            return new ActuatorValue
            {
                Name = actuatorValue.Name,
                Type = actuatorValue.Type,
                Default = actuatorValue.Default
            };
        }
    }
}