using System;
using System.Collections.Generic;
using Core.Device.Api.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Device.Api.Models.Domain
{
    public class Device
    {
        public ObjectId Id { get; set; }

        public ObjectId TypeId { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string TenantId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateAdded { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public MessageProtocols MessageProtocols { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ThingType ThingTypes { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Image> Icons { get; set; }

        public IEnumerable<ActuatorValue> ActuatorValues { get; set; }

        public IEnumerable<SensorValue> SensorValues { get; set; }
    }
}