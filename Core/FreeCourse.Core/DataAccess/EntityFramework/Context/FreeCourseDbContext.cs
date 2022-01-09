using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FreeCourse.Core.DataAccess.EntityFramework.Context
{
    public class FreeCourseDbContext:DbContext
    {
        public IConfiguration Configuration { get; }
        public FreeCourseDbContext(DbContextOptions<FreeCourseDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected FreeCourseDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
    }
}
