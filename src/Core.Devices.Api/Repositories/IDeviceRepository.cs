using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Devices.Api.Models.DTO;
using MongoDB.Bson;
using UserDevice = Core.Devices.Api.Models.Domain.UserDevice;

namespace Core.Devices.Api.Repositories
{
    public interface IDeviceRepository
    {
        Task Create(
            UserDevice userDevice, 
            CancellationToken cancellationToken);
        
        Task<IEnumerable<UserDevice>> Fetch(
            string userId, 
            CancellationToken cancellationToken);
        
        Task<UserDevice> Update(
            string userId, 
            ObjectId id, 
            UpdateUserDevice userDevice, 
            CancellationToken cancellationToken);
        
        Task<UserDevice> Delete(
            ObjectId id, 
            string userId, 
            CancellationToken cancellationToken);
    }
}