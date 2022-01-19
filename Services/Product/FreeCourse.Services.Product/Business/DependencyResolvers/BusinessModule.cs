using FreeCourse.Core.Utilities.IoC;
using FreeCourse.Services.Product.Business.Abstract;
using FreeCourse.Services.Product.Business.Concrete;
using FreeCourse.Services.Product.DataAccess.Abstract;
using FreeCourse.Services.Product.DataAccess.Concrete.EntityFramework.MSSQL;
using FreeCourse.Services.Product.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Services.Product.Business.DependencyResolvers
{
    public class BusinessModule:ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MssqlDbContext>();
            
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
        }
    }
}
