using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Core.Aspects.Validation;
using FreeCourse.Services.DiscountEfCore.Business.Abstract;
using FreeCourse.Services.DiscountEfCore.Business.Validation;
using FreeCourse.Services.DiscountEfCore.DataAccess.Abstract;
using FreeCourse.Services.DiscountEfCore.Entities;
using FreeCourse.Shared.Dto;
using FreeCourse.Shared.Services;

namespace FreeCourse.Services.DiscountEfCore.Business.Concrete
{
    public class DiscountManager:IDiscountService
    {
        private readonly IDiscountDal _discountDal;
        ISharedIdentityService _sharedIdentityService;

        public DiscountManager(IDiscountDal discountDal, ISharedIdentityService sharedIdentityService)
        {
            _discountDal = discountDal;
            _sharedIdentityService= sharedIdentityService;
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

            discount.UserId = _sharedIdentityService.GetUserId;
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

        public async Task<Response<Discount>> GetByCode(string code)
        {
            var result = await _discountDal.GetAsync(x => x.DiscountCode == code);
            return Response<Discount>.Success(result, 200);
        }
    }
}
