using FluentValidation;
using FreeCourse.Web.Models.Catalogs;

namespace FreeCourse.Web.Validators
{
    public class CourseCreateInputValidator:AbstractValidator<CourseCreateInput>
    {
        public CourseCreateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Isim Alani Bos Olamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("aciklama bos olamaz");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("sure alani bos olamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("fiyat alani bos olamaz").ScalePrecision(2, 6).WithMessage("hatali para formati");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("kategori alani seciniz");

        }
    }
}
