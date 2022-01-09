using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FreeCourse.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyResolvers(this IServiceCollection serviceCollection,
            IConfiguration configuration, params ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
               module.Load(serviceCollection,configuration);
            }
        }
    }
}
