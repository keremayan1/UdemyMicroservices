using FreeCourse.Core.Utilities.IoC;
using FreeCourse.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Web.Extensions
{
    public  class ServicesConfigure:ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
            services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));
        }
    }
}
