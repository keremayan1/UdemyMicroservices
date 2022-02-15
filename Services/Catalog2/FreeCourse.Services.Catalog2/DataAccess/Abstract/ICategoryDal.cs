using FreeCourse.Core.DataAccess.MongoDb;
using FreeCourse.Services.Catalog2.Entities;

namespace FreeCourse.Services.Catalog2.DataAccess.Abstract
{
    public interface ICategoryDal:IMongoDbRepository<Category>
    {
    }
}
