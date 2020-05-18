using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Devices.Api.Models.DTO;

namespace Core.Devices.Api.Services
{
    public interface IUserDeviceService
    {
        Task<UserDevice> Create(
            CreateUserDevice userDevice, 
            string userId,
            string tenantId,
            CancellationToken cancellationToken);
        
        Task<UserDevice> Delete(
            string id, 
            string userId, 
            CancellationToken cancellationToken);
        
        Task<UserDevice> Update(
            string id,
            UpdateUserDevice userDevice, 
            string userId, 
            CancellationToken cancellationToken);
        
        Task<IEnumerable<UserDevice>> Fetch(
            string userId, 
            CancellationToken cancellationToken);
    }
}