using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Mappers;
using Core.Device.Api.Models.DTO;
using Core.Device.Api.Repositories;
using MongoDB.Bson;
using Type = Core.Device.Api.Models.DTO.Type;

namespace Core.Device.Api.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(
            ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        
        public async Task<Models.DTO.Type> Create(
            CreateType type, 
            string tenantId, 
            CancellationToken cancellationToken)
        {
            var newType = TypeMapper.MapToDomain(
                type,
                tenantId);
            
            await _typeRepository.Create(
                newType,
                cancellationToken);

            return TypeMapper.MapToDto(newType);
        }

        public async Task<Models.DTO.Type> Delete(
            string id, 
            string tenantId, 
            CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(id, out var typeId))
            {
                throw new ArgumentException("Invalid Id, cannot cast to ObjectId.");
            }

            var deletedDevice = await _typeRepository.Delete(
                typeId,
                tenantId,
                cancellationToken);
                
            return TypeMapper.MapToDto(deletedDevice);
        }

        public async Task<Models.DTO.Type> Update(
            string id,
            string tenantId,
            UpdateType type,
            CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(id, out var typeId))
            {
                throw new ArgumentException("Invalid Id, cannot cast to ObjectId.");
            }
            
            var typeToUpdate = TypeMapper.MapToDomain(
                typeId,
                type,
                tenantId);
            
            var updatedType = await _typeRepository.Update(
                typeToUpdate,
                cancellationToken);

            return TypeMapper.MapToDto(updatedType);
        }

        public async Task<Models.DTO.Type> Get(
            string id, 
            string tenantId, 
            CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(id, out var typeId))
            {
                throw new ArgumentException("Invalid Id, cannot cast to ObjectId.");
            }
            
            var device = await _typeRepository.Get(
                typeId,
                tenantId,
                cancellationToken);
            
            return TypeMapper.MapToDto(device);
        }

        public async Task<IEnumerable<Models.DTO.Type>> Fetch(
            string tenantId, 
            CancellationToken cancellationToken)
        {
            var devices = await _typeRepository.Fetch(
                tenantId,
                cancellationToken);

            return devices?.Select(TypeMapper.MapToDto) ?? new List<Models.DTO.Type>();
        }
    }
}