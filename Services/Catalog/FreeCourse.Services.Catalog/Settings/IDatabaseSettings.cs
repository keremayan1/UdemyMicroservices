namespace FreeCourse.Services.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        string CourseCollectionName { get; }
        string CategoryCollectionName { get; }
        string ConnectionStrings { get; }
        string DatabaseName { get; }


    }
}
