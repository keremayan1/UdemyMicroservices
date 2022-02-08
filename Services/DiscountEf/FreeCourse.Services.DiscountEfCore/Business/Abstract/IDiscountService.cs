using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.DiscountEfCore.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.DiscountEfCore.Business.Abstract
{
    public interface IDiscountService
    {
        Task<Response<List<Discount>>> GetAll();
        Task<Response<Discount>> GetById(int id);
        Task<Response<NoContent>> Save(Discount discount);
        Task<Response<NoContent>> Update(Discount discount);
        Task<Response<NoContent>> Delete(int id);
        Task<Response<Discount>> GetByCodeAndUserId(string code, string userId);
        Task<Response<Discount>> GetByCode(string code);
    }
}
