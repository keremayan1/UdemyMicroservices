using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Core.DataAccess.EntityFramework;
using FreeCourse.Core.DataAccess.EntityFramework.Concrete;
using FreeCourse.Core.DataAccess.EntityFramework.Context;
using FreeCourse.Core.Extensions;
using FreeCourse.Services.Product.Business.Abstract;
using FreeCourse.Services.Product.Business.Concrete;
using FreeCourse.Services.Product.Business.DependencyResolvers;
using FreeCourse.Services.Product.DataAccess.Abstract;
using FreeCourse.Services.Product.DataAccess.Concrete.EntityFramework.MSSQL;
using FreeCourse.Services.Product.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Product
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {





         

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FreeCourse.Services.Product", Version = "v1" });
            });
            services.AddDependencyResolvers(Configuration,new BusinessModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FreeCourse.Services.Product v1"));
            }
         
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
