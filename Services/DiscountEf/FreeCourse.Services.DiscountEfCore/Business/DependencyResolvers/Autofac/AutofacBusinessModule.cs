using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FreeCourse.Core.Utilities.Interceptors;
using FreeCourse.Core.Utilities.IoC;
using FreeCourse.Services.DiscountEfCore.Business.Abstract;
using FreeCourse.Services.DiscountEfCore.Business.Concrete;
using FreeCourse.Services.DiscountEfCore.DataAccess.Abstract;
using FreeCourse.Services.DiscountEfCore.DataAccess.Concrete.PostgreSQL;
using FreeCourse.Services.DiscountEfCore.DataAccess.Concrete.PostgreSQL.Context;
using Module = Autofac.Module;

namespace FreeCourse.Services.DiscountEfCore.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DiscountManager>().As<IDiscountService>().InstancePerLifetimeScope();
            builder.RegisterType<EfPDiscountDal>().As<IDiscountDal>().InstancePerLifetimeScope();
            //builder.RegisterType<PostgreSqlContext>().AsImplementedInterfaces().InstancePerLifetimeScope();


            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
