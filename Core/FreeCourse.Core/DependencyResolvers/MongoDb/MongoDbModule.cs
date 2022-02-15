using FreeCourse.Core.Entities.MongoDb;
using FreeCourse.Core.Entities.MongoDb.Concrete;
using FreeCourse.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FreeCourse.Core.DependencyResolvers.MongoDb
{
    public class MongoDbModule:ICoreModule
    {
      

    
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddSingleton<IMongoDbConnectionSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbConnectionSettings>>().Value);
          
        }
      
    }
}
