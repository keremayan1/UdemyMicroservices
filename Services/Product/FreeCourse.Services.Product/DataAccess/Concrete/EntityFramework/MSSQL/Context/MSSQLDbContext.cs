using FreeCourse.Core.DataAccess.EntityFramework.Context;
using FreeCourse.Services.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FreeCourse.Services.Product.DataAccess.Concrete.EntityFramework.MSSQL.Context
{
    public class MssqlDbContext: FreeCourseDbContext
    {
        

        public DbSet<Entities.Product> Products { get; set; }

     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MssqlDbContext"));
        }

        public MssqlDbContext(DbContextOptions<MssqlDbContext> options, IConfiguration configuration) : base(options, configuration)
        {
        }

      
    }
}
