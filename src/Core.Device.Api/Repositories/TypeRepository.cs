using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.Domain;
using Core.Device.Api.Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Device.Api.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly IMongoCollection<Type> _deviceCollection;
        
        public TypeRepository(
            IOptions<DeviceDatabaseSettings> devicesDatabaseSettings)
        {
            var client = new MongoClient(devicesDatabaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(devicesDatabaseSettings.Value.DatabaseName);
            _deviceCollection = database.GetCollection<Type>(devicesDatabaseSettings.Value.TypeCollectionName);
        }
        
        public async Task Create(
            Type type, 
            CancellationToken cancellationToken) => await _deviceCollection.InsertOneAsync(
                type, 
                null,
                cancellationToken);

        public async Task<IEnumerable<Type>> Fetch(
            string tenantId, 
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<Type>(i => i.TenantId == tenantId);
            var results = await _deviceCollection.FindAsync(
                filter, 
                null, 
                cancellationToken);
            return results.ToList();
        }

        public async Task<Type> Get(
            ObjectId id, 
            string tenantId, 
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<Type>(i => i.Id == id && i.TenantId == tenantId);
            var results = await _deviceCollection.FindAsync(
                filter, 
                null, 
                cancellationToken);
            return results?.FirstOrDefault();
        }

        public async Task<Type> Update(
            Type type, 
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<Type>(i =>
                i.TenantId == type.TenantId &&
                i.Id == type.Id);

            var updateDefinition = new UpdateDefinitionBuilder<Type>();
            updateDefinition.Set(d => d.Name, type.Name);
            updateDefinition.Set(d => d.Icons, type.Icons);
            updateDefinition.Set(d => d.Images, type.Images);
            updateDefinition.Set(d => d.ActuatorValues, type.ActuatorValues);
            updateDefinition.Set(d => d.SensorValues, type.SensorValues);
            updateDefinition.Set(d => d.MessageProtocols, type.MessageProtocols);
            updateDefinition.Set(d => d.ThingTypes, type.ThingTypes);

            return await _deviceCollection.FindOneAndUpdateAsync<Type>(
                filter,
                updateDefinition.Combine(),
                null,
                cancellationToken);
        }

        public async Task<Type> Delete(
            ObjectId id, 
            string tenantId, 
            CancellationToken cancellationToken)
        {
            var filter = new ExpressionFilterDefinition<Type>(i => 
                i.TenantId == tenantId && 
                i.Id == id);
            return await _deviceCollection.FindOneAndDeleteAsync(
                filter,
                null, 
                cancellationToken);
        }
    }
}