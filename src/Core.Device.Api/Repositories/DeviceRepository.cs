using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.Settings;
using Core.Device.Api.Models.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Device.Api.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IMongoCollection<Models.Domain.Device> _deviceCollection;
        
        public DeviceRepository(
            IOptions<DeviceDatabaseSettings> devicesDatabaseSettings)
        {
            var client = new MongoClient(devicesDatabaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(devicesDatabaseSettings.Value.DatabaseName);
            _deviceCollection = database.GetCollection<Models.Domain.Device>(devicesDatabaseSettings.Value.DeviceCollectionName);
        }

        public async Task Create(
            Models.Domain.Device device,
            CancellationToken cancellationToken) => await _deviceCollection.InsertOneAsync(
                device, 
                null,
                cancellationToken);
        
        public async Task<Models.Domain.Device> Delete(
            ObjectId id, 
            string userId, 
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<Models.Domain.Device>(i => i.UserId == userId && i.Id == id);
            return await _deviceCollection.FindOneAndDeleteAsync(
                filter,
                null, 
                cancellationToken);
        }

        public async Task<Models.Domain.Device> Update(
            Models.Domain.Device device, 
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<Models.Domain.Device>(i =>
                i.UserId == device.UserId &&
                i.Id == device.Id);

            var updateDefinition = new UpdateDefinitionBuilder<Models.Domain.Device>();
            updateDefinition.Set(d => d.Name, device.Name);
            updateDefinition.Set(d => d.ThingTypes, device.ThingTypes);

            return await _deviceCollection.FindOneAndUpdateAsync<Models.Domain.Device>(
                filter,
                updateDefinition.Combine(),
                null,
                cancellationToken);
        }
        
        public async Task<IEnumerable<Models.Domain.Device>> Fetch(
            string userId,
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<Models.Domain.Device>(i => i.UserId == userId);
            var results = await _deviceCollection.FindAsync(
                filter, 
                null, 
                cancellationToken);
            return results.ToList();
        }
    }
}