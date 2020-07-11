using System;
using System.Linq;
using Core.Device.Api.Models.DTO;
using MongoDB.Bson;
using DtoType = Core.Device.Api.Models.DTO.Type;
using DomainType = Core.Device.Api.Models.Domain.Type;
using Type = Core.Device.Api.Models.DTO.Type;

namespace Core.Device.Api.Mappers
{
    public static class TypeMapper
    {
        public static Type MapToDto(
            Models.Domain.Type type)
        {
            return new Type
            {
                Id = type.Id.ToString(),
                Name = type.Name,
                ThingTypes = type.ThingTypes
            };
        }

        public static Models.Domain.Type MapToDomain(
            CreateType type,
            string tenantId)
        {
            return new Models.Domain.Type
            {
                Icons = type.Icons.Select(ImageMapper.MapToDomain),
                Images = type.Images.Select(ImageMapper.MapToDomain),
                DateAdded = DateTime.UtcNow,
                TenantId = tenantId,
                Name = type.Name,
                ActuatorValues = type.ActuatorValues.Select(ActuatorValueMapper.MapToDomain),
                SensorValues = type.SensorValues.Select(SensorValueMapper.MapToDomain),
                MessageProtocols = type.MessageProtocols,
                ThingTypes = type.ThingTypes
            };
        }

        public static Models.Domain.Type MapToDomain(
            ObjectId id,
            UpdateType type,
            string tenantId)
        {
            return new Models.Domain.Type
            {
                Id = id,
                TenantId = tenantId,
                Name = type.Name,
                Icons = type.Icons.Select(ImageMapper.MapToDomain),
                Images = type.Images.Select(ImageMapper.MapToDomain),
                ActuatorValues = type.ActuatorValues.Select(ActuatorValueMapper.MapToDomain),
                SensorValues = type.SensorValues.Select(SensorValueMapper.MapToDomain),
                MessageProtocols = type.MessageProtocols,
                ThingTypes = type.ThingTypes
            };
        }
    }
}