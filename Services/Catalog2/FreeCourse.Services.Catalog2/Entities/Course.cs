using FreeCourse.Core.Entities.MongoDb.Concrete;

namespace FreeCourse.Services.Catalog2.Entities
{
    public class Course:MongoBaseEntity
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }

    }
}
