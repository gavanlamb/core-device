using System;
using System.Linq;
using Core.Device.Api.Models.DTO;
using MongoDB.Bson;
using DtoDevice = Core.Device.Api.Models.DTO.Device;
using DomainDevice = Core.Device.Api.Models.Domain.Device;
using Type = Core.Device.Api.Models.Domain.Type;

namespace Core.Device.Api.Mappers
{
    public static class DeviceMapper
    {
        public static Models.DTO.Device MapToDto(
            Models.Domain.Device device)
        {
            return new Models.DTO.Device
            {
                Id = device.Id.ToString(),
                Name = device.Name,
                ThingTypes = device.ThingTypes
            };
        }
        
        public static Models.Domain.Device MapToDomain(
            RegisterDevice device,
            Models.Domain.Type type,
            string userId,
            string tenantId)
        {
            return new Models.Domain.Device
            {
                Name = device.Name,
                TypeId = type.Id,
                TenantId = tenantId,
                UserId = userId,
                ThingTypes = type.ThingTypes,
                Icons = type.Icons,
                Images = type.Images,
                ActuatorValues = type.ActuatorValues,
                SensorValues = type.SensorValues,
                DateAdded = DateTime.UtcNow,
                MessageProtocols = type.MessageProtocols
            };
        }
        
        public static Models.Domain.Device MapToDomain(
            ObjectId id, 
            string userId, 
            string tenantId,
            UpdateDevice device)
        {
            return new Models.Domain.Device
            {
                Id = id,
                Name = device.Name,
                TenantId = tenantId,
                UserId = userId,
                ThingTypes = device.ThingTypes,
                Icons = device.Icons.Select(ImageMapper.MapToDomain),
                Images = device.Images.Select(ImageMapper.MapToDomain),
                ActuatorValues = device.ActuatorValues.Select(ActuatorValueMapper.MapToDomain),
                SensorValues = device.SensorValues.Select(SensorValueMapper.MapToDomain),
                DateAdded = DateTime.UtcNow,
                MessageProtocols = device.MessageProtocols
            };
        }
    }
}