using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeCourse.Core.Entities.MongoDb;
using FreeCourse.Core.Entities.MongoDb.Concrete;
using Microsoft.Extensions.Configuration;

namespace FreeCourse.Core.DataAccess.MongoDb.Context
{
    public abstract class MongoDbContextBase
    {
        public readonly IConfiguration configuration;
        public readonly MongoDbConnectionSettings connectionSettings;

        public MongoDbContextBase(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionSettings = configuration.GetSection("MongoDbConnectionSettings").Get<MongoDbConnectionSettings>();

        }
    }
}
