using Core.Devices.Api.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Devices.Api.Models.Domain
{
    public class UserDevice
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public DeviceType Types { get; set; }

        public string UserId { get; set; }
        
        public string TenantId { get; set; }
    }
}