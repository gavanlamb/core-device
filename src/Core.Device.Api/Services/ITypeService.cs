using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.DTO;

namespace Core.Device.Api.Services
{
    public interface ITypeService
    {
        Task<Type> Create(
            CreateType type,
            string tenantId,
            CancellationToken cancellationToken);
        
        Task<Type> Delete(
            string id, 
            string tenantId, 
            CancellationToken cancellationToken);
        
        Task<Type> Update(
            string id,
            string tenantId, 
            UpdateType device, 
            CancellationToken cancellationToken);
        
        Task<Type> Get(
            string id, 
            string tenantId, 
            CancellationToken cancellationToken);
        
        Task<IEnumerable<Type>> Fetch(
            string tenantId, 
            CancellationToken cancellationToken);
    }
}