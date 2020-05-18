using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Devices.Api.Extensions;
using Core.Devices.Api.Models.DTO;
using Core.Devices.Api.Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using DomainUserDevice = Core.Devices.Api.Models.Domain.UserDevice;

namespace Core.Devices.Api.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IMongoCollection<DomainUserDevice> _deviceCollection;
        
        public DeviceRepository(
            IOptions<DevicesDatabaseSettings> devicesDatabaseSettings)
        {
            var client = new MongoClient(devicesDatabaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(devicesDatabaseSettings.Value.DatabaseName);
            _deviceCollection = database.GetCollection<DomainUserDevice>(devicesDatabaseSettings.Value.UserDevicesCollectionName);
        }

        public async Task Create(
            DomainUserDevice userDevice,
            CancellationToken cancellationToken) => await _deviceCollection.InsertOneAsync(
                userDevice, 
                null,
                cancellationToken);
        
        public async Task<DomainUserDevice> Delete(
            ObjectId id, 
            string userId, 
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<DomainUserDevice>(i => i.UserId == userId && i.Id == id);
            return await _deviceCollection.FindOneAndDeleteAsync(
                filter,
                null, 
                cancellationToken);
        }

        public async Task<DomainUserDevice> Update(
            string userId,
            ObjectId id, 
            UpdateUserDevice userDevice,
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<DomainUserDevice>(i =>
                i.UserId == userId &&
                i.Id == id);

            var updateDefinition = new UpdateDefinitionBuilder<DomainUserDevice>();

            if (userDevice.Name != null)
            {
                updateDefinition.Set(d => d.Name, userDevice.Name);
            }

            if (userDevice.Types != null)
            {
                updateDefinition.Set(d => d.Types, userDevice.Types);
            }

            return await _deviceCollection.FindOneAndUpdateAsync<DomainUserDevice>(
                filter,
                updateDefinition.Combine(),
                null,
                cancellationToken);
        }
        
        public async Task<IEnumerable<DomainUserDevice>> Fetch(
            string userId,
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<DomainUserDevice>(i => i.UserId == userId);
            var results = await _deviceCollection.FindAsync(
                filter, 
                null, 
                cancellationToken);
            return results.ToList();
        }
    }
}