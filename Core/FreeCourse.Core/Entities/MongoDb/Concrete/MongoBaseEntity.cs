using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Core.Entities.MongoDb.Concrete
{
    public  class MongoBaseEntity:IMongoDbEntity
    {

    
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
