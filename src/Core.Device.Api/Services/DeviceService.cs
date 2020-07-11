using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Mappers;
using Core.Device.Api.Models.DTO;
using Core.Device.Api.Repositories;
using MongoDB.Bson;
using DtoDevice = Core.Device.Api.Models.DTO.Device;
using DomainDevice = Core.Device.Api.Models.Domain.Device;

namespace Core.Device.Api.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ITypeRepository _typeRepository;

        public DeviceService(
            IDeviceRepository deviceRepository,
            ITypeRepository typeRepository)
        {
            _deviceRepository = deviceRepository;
            _typeRepository = typeRepository;
        }
        
        public async Task<Models.DTO.Device> Create(
            string userId,
            string tenantId,
            RegisterDevice device, 
            CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(device.TypeId, out var deviceId))
            {
                throw new ArgumentException("Invalid TypeId");
            }
            
            var type = await _typeRepository.Get(
                deviceId,
                tenantId, 
                cancellationToken) 
                    ?? 
                throw new ArgumentException("Type not found.");
            
            var newDevice = DeviceMapper.MapToDomain(
                device, 
                type, 
                userId,
                tenantId);

            await _deviceRepository.Create(
                newDevice,
                cancellationToken);

            return DeviceMapper.MapToDto(newDevice);
        }

        public async Task<Models.DTO.Device> Delete(
            string id,
            string userId,
            CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(id, out var deviceId))
            {
                throw new ArgumentException("Invalid Id, cannot cast to ObjectId.");
            }

            var device = await _deviceRepository.Delete(
                deviceId,
                userId,
                cancellationToken);
                
            return DeviceMapper.MapToDto(device);
        }

        public async Task<Models.DTO.Device> Update(
            string id,
            string userId,
            string tenantId,
            UpdateDevice device, 
            CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(id, out var deviceId))
            {
                throw new ArgumentException("Invalid Id, cannot cast to ObjectId.");
            }

            var deviceToUpdate = DeviceMapper.MapToDomain(
                deviceId,
                userId,
                tenantId,
                device);
            
            var updatedDevice = await _deviceRepository.Update(
                deviceToUpdate,
                cancellationToken);

            return DeviceMapper.MapToDto(updatedDevice);
        }

        public async Task<IEnumerable<Models.DTO.Device>> Fetch(
            string userId, 
            CancellationToken cancellationToken)
        {
            var devices = await _deviceRepository.Fetch(
                userId,
                cancellationToken);

            return devices?.Select(DeviceMapper.MapToDto) ?? new List<Models.DTO.Device>();
        }
    }
}