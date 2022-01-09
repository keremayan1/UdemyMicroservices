using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FreeCourse.Shared.Dto;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace FreeCourse.Services.Discount.Services
{
    public class DiscountService:IDiscountService
    {
        private IConfiguration _configuration;
        private IDbConnection _connection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }


        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discount = await _connection.QueryAsync<Models.Discount>("select * from discount");
            return Response<List<Models.Discount>>.Success(discount.ToList(),200);
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discounts =
                (await _connection.QueryAsync<Models.Discount>("select * from discount where id=@Id", new { Id=id })).SingleOrDefault();
            return discounts==null? Response<Models.Discount>.Fail("Discount not found", 404) : Response<Models.Discount>.Success(discounts, 200);
          

        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var saveStatus = await _connection.ExecuteAsync(
                "insert into discount(userId,rate,discountCode)values(@userid,@rate,@discountCode)",
                discount);
            return saveStatus>0? Response<NoContent>.Success(204): Response<NoContent>.Fail("an error accured while adding", 500);
         
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var updatedStatus = await _connection.ExecuteAsync(
                "update discount set userId=@userid,rate=@rate,discountCode=@discountCode  where id=@id",
                discount);

            return updatedStatus>0 ?  Response<NoContent>.Success(204): Response<NoContent>.Fail("discount not found", 404);
            
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var deletedStatus = await _connection.ExecuteAsync("delete from discount where id=@id", new { Id = id });

            return deletedStatus>0? Response<NoContent>.Success(204) : Response<NoContent>.Fail("an error accured while deleting", 404);
          
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _connection.QueryAsync<Models.Discount>(
                "select * from discount where userid=@UserId and discountcode=@Code", new { Code = code, UserId = userId });
            var hasDiscount = discounts.FirstOrDefault();
            return hasDiscount==null? Response<Models.Discount>.Fail("Code or UserId not found", 404): Response<Models.Discount>.Success(hasDiscount,200);
         
        }
    }
}
