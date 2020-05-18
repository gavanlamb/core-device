using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Devices.Api.Extensions;
using Core.Devices.Api.Mappers;
using Core.Devices.Api.Models.DTO;
using Core.Devices.Api.Repositories;
using MongoDB.Bson;
using UserDevice = Core.Devices.Api.Models.DTO.UserDevice;

namespace Core.Devices.Api.Services
{
    public class UserDeviceService : IUserDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public UserDeviceService(
            IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        
        public async Task<UserDevice> Create(
            CreateUserDevice userDevice, 
            string userId,
            string tenantId,
            CancellationToken cancellationToken)
        {
            //TODO validation on the userDevice object
            
            var newDevice = new Models.Domain.UserDevice
            {
                Name = userDevice.Name,
                Types = userDevice.Types,
                TenantId = tenantId,
                UserId = userId
            };
            
            await _deviceRepository
                .Create(
                    newDevice,
                    cancellationToken);

            return UserDeviceMapper.MapToDto(newDevice);
        }

        public async Task<UserDevice> Delete(
            string id,
            string userId,
            CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("Invalid Id, cannot cast to ObjectId.");
            }

            var userDevice = await _deviceRepository.Delete(
                objectId,
                userId,
                cancellationToken);
                
            return UserDeviceMapper.MapToDto(userDevice);
        }

        public async Task<UserDevice> Update(
            string id,
            UpdateUserDevice userDevice, 
            string userId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(userDevice.Name) && userDevice.Types == null)
            {
                throw new ArgumentException($"No changes detected for device:${id}");
            }
            
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("Invalid Id, cannot cast to ObjectId.");
            }

            var updatedUserDevice = await _deviceRepository.Update(
                userId,
                objectId,
                userDevice,
                cancellationToken);

            return UserDeviceMapper.MapToDto(updatedUserDevice);
        }

        public async Task<IEnumerable<UserDevice>> Fetch(
            string userId, 
            CancellationToken cancellationToken)
        {
            var userDevices = await _deviceRepository.Fetch(
                userId,
                cancellationToken);

            if (!userDevices.IsNullOrEmpty())
            {
                return userDevices.Select(UserDeviceMapper.MapToDto);
            }

            return new List<UserDevice>();
        }
    }
}