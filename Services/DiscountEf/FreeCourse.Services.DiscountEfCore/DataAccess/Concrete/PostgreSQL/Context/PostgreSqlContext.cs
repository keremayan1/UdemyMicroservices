using FreeCourse.Core.DataAccess.EntityFramework.Context;
using FreeCourse.Services.DiscountEfCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FreeCourse.Services.DiscountEfCore.DataAccess.Concrete.PostgreSQL.Context
{
    public class PostgreSqlContext:FreeCourseDbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, IConfiguration configuration) : base(options, configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PostgreSqlDbContext"));
        }

        public DbSet<Discount> Discounts { get; set; }
    }
}
