using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Core.Aspects.Validation;
using FreeCourse.Services.DiscountEfCore.Business.Abstract;
using FreeCourse.Services.DiscountEfCore.Business.Validation;
using FreeCourse.Services.DiscountEfCore.DataAccess.Abstract;
using FreeCourse.Services.DiscountEfCore.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.DiscountEfCore.Business.Concrete
{
    public class DiscountManager:IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public async Task<Response<List<Discount>>> GetAll()
        {
            var result = await _discountDal.GetAllAsync();
            return Response<List<Discount>>.Success(result,200);
        }

        public async Task<Response<Discount>> GetById(int id)
        {
            var result = await _discountDal.GetAsync(d => d.Id == id);
            return Response<Discount>.Success(result, 200);
        }

        [ValidationAspect(typeof(DiscountValidator),Priority = 1)]
        public async Task<Response<NoContent>> Save(Discount discount)
        {
         

            await _discountDal.AddAsync(discount);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> Update(Discount discount)
        {
            await _discountDal.UpdateAsync(discount);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var getId = await _discountDal.GetAsync(x => x.Id == id);
            await _discountDal.DeleteAsync(getId);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var result = await _discountDal.GetAsync(x => x.DiscountCode == code && x.UserId == userId);
            return Response<Discount>.Success(result, 200);
        }
    }
}
