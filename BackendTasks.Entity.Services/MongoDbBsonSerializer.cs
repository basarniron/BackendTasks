using BackendTasks.Entity.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace BackendTasks.Entity.Services
{
    public static class MongoDbBsonSerializer
    {
        public static void Configure()
        {
            // Set Guid to CSharp style (with dash -)
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);

            //BsonClassMap.RegisterClassMap<Adviser>(map =>
            //{
            //    map.AutoMap();
            //    map.SetIgnoreExtraElements(true);
            //    map.MapProperty(x => x.Id).SetSerializer(new GuidSerializer(BsonType.String));
            //});
        }
    }
}
