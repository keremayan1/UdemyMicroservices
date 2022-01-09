using MongoDB.Driver;

namespace FreeCourse.Core.Entities.MongoDb
{
    public class MongoDbConnectionSettings : IMongoDbConnectionSettings
    {
        private MongoClientSettings _clientSettings { get; set; }

        public MongoDbConnectionSettings(MongoClientSettings clientSettings)
        {
            _clientSettings = clientSettings;
        }

        public MongoDbConnectionSettings()
        {
            
        }

        public MongoClientSettings GetMongoClientSettings()
        {
            return _clientSettings;
        }
        public virtual string ConnectionStrings { get; set; }

        public string DatabaseName { get; set; }
    }
}
