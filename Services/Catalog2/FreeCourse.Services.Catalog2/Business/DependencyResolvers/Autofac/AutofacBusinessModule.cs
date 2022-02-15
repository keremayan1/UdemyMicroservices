using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FreeCourse.Core.DataAccess.MongoDb.Context;
using FreeCourse.Core.Utilities.Interceptors;
using FreeCourse.Services.Catalog2.Business.Abstract;
using FreeCourse.Services.Catalog2.Business.Concrete;
using FreeCourse.Services.Catalog2.DataAccess.Abstract;
using FreeCourse.Services.Catalog2.DataAccess.Concrete.MongoDb;
using FreeCourse.Services.Catalog2.DataAccess.Concrete.MongoDb.Context;
using FreeCourse.Services.Catalog2.Entities;
using Module = Autofac.Module;

namespace FreeCourse.Services.Catalog2.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDbContext>().As<MongoDbContextBase>().InstancePerLifetimeScope();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<MongoDbCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();

            builder.RegisterType<CourseManager>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<MongoDbCourseDal>().As<ICourseDal>().InstancePerLifetimeScope();

          


            
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance().InstancePerDependency();
        }
    }
}
