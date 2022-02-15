using FluentValidation;
using FreeCourse.Services.DiscountEfCore.Entities;

namespace FreeCourse.Services.DiscountEfCore.Business.Validation
{
    public class DiscountValidator:AbstractValidator<Discount>
    {
        public DiscountValidator()
        {
            
            RuleFor(x => x.Rate).NotEmpty();
        }
    }
}
