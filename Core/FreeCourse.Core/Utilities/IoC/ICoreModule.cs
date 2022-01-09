using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services,IConfiguration configuration);
    }
}
