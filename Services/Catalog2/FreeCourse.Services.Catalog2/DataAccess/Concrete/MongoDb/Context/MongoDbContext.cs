using FreeCourse.Core.DataAccess.MongoDb.Context;
using Microsoft.Extensions.Configuration;

namespace FreeCourse.Services.Catalog2.DataAccess.Concrete.MongoDb.Context
{
    public class MongoDbContext:MongoDbContextBase
    {
        public MongoDbContext(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
