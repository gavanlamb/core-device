using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.Domain;
using Dto = Core.Device.Api.Models.DTO;
using MongoDB.Bson;

namespace Core.Device.Api.Repositories
{
    public interface ITypeRepository
    {
        Task Create(
            Type type, 
            CancellationToken cancellationToken);
        
        Task<IEnumerable<Type>> Fetch(
            string tenantId, 
            CancellationToken cancellationToken);

        Task<Type> Get(
            ObjectId id,
            string tenantId, 
            CancellationToken cancellationToken);
        
        Task<Type> Update(
            Type type, 
            CancellationToken cancellationToken);
        
        Task<Type> Delete(
            ObjectId id, 
            string tenantId, 
            CancellationToken cancellationToken);
    }
}