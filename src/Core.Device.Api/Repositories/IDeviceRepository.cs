using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.DTO;
using Core.Device.Api.Models.Enum;
using MongoDB.Bson;
using Device = Core.Device.Api.Models.Domain.Device;

namespace Core.Device.Api.Repositories
{
    public interface IDeviceRepository
    {
        Task Create(
            Models.Domain.Device device, 
            CancellationToken cancellationToken);
        
        Task<IEnumerable<Models.Domain.Device>> Fetch(
            string userId, 
            CancellationToken cancellationToken);
        
        Task<Models.Domain.Device> Update(
            Models.Domain.Device device, 
            CancellationToken cancellationToken);
        
        Task<Models.Domain.Device> Delete(
            ObjectId id, 
            string userId, 
            CancellationToken cancellationToken);
    }
}