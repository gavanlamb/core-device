using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.DTO;

namespace Core.Device.Api.Services
{
    public interface IDeviceService
    {
        Task<Models.DTO.Device> Create(
            string userId,
            string tenantId,
            RegisterDevice device, 
            CancellationToken cancellationToken);
        
        Task<Models.DTO.Device> Delete(
            string id, 
            string userId, 
            CancellationToken cancellationToken);
        
        Task<Models.DTO.Device> Update(
            string id,
            string userId, 
            string tenantId,
            UpdateDevice device, 
            CancellationToken cancellationToken);
        
        Task<IEnumerable<Models.DTO.Device>> Fetch(
            string userId, 
            CancellationToken cancellationToken);
    }
}