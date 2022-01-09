namespace FreeCourse.Core.Entities.MongoDb
{
    public interface IMongoDbConnectionSettings
    {
        
        string ConnectionStrings { get; }
        string DatabaseName { get; }


    }
}
