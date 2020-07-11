using Core.Device.Api.Models.Domain;
using DomainSensorValue = Core.Device.Api.Models.Domain.SensorValue;
using DtoSensorValue = Core.Device.Api.Models.DTO.SensorValue;

namespace Core.Device.Api.Mappers
{
    public static class SensorValueMapper
    {
        public static SensorValue MapToDomain(
            Models.DTO.SensorValue actuatorValue)
        {
            return new SensorValue
            {
                Name = actuatorValue.Name,
                Type = actuatorValue.Type,
                Default = actuatorValue.Default
            };
        }
    }
}