using FreeCourse.Core.Utilities.IoC;
using FreeCourse.Shared.Services;
using FreeCourse.Web.Handler;
using FreeCourse.Web.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Web.Extensions
{
    public  class ServicesDI : ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<PhotoHelper>();
            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<ClientCredentialTokenHandler>();
            services.AddScoped<ISharedIdentityService, SharedIdentityService>();
        }
    }
}
