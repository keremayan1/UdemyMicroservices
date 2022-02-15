using System.Collections.Generic;
using FreeCourse.Core.DataAccess.MongoDb.Concrete;
using FreeCourse.Core.DataAccess.MongoDb.Context;
using FreeCourse.Core.Entities.MongoDb;
using FreeCourse.Services.Catalog2.DataAccess.Abstract;
using FreeCourse.Services.Catalog2.DataAccess.Concrete.MongoDb.Context;
using FreeCourse.Services.Catalog2.Entities;

namespace FreeCourse.Services.Catalog2.DataAccess.Concrete.MongoDb
{
    public class MongoDbCategoryDal : MongoDbRepository<Category>, ICategoryDal
    {
        public MongoDbCategoryDal(MongoDbContextBase connectionSettings) : base(connectionSettings.connectionSettings)
        { 
            
        }

        
    }
}

