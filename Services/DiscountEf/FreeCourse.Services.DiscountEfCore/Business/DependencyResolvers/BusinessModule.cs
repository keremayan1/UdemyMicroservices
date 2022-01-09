using FreeCourse.Core.Utilities.IoC;
using FreeCourse.Services.DiscountEfCore.Business.Abstract;
using FreeCourse.Services.DiscountEfCore.Business.Concrete;
using FreeCourse.Services.DiscountEfCore.DataAccess.Abstract;
using FreeCourse.Services.DiscountEfCore.DataAccess.Concrete.PostgreSQL;
using FreeCourse.Services.DiscountEfCore.DataAccess.Concrete.PostgreSQL.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Services.DiscountEfCore.Business.DependencyResolvers
{
    public class BusinessModule:ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgreSqlContext>();
        }
    }
}
