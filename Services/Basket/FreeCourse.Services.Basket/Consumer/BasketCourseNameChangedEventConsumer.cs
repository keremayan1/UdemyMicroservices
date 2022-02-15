
using FreeCourse.Services.Basket.Dto;
using FreeCourse.Services.Basket.Redis.DataAccess;
using FreeCourse.Services.Basket.Services;
using FreeCourse.Shared.Messages;
using MassTransit;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Consumer
{
    public class BasketCourseNameChangedEventConsumer : IConsumer<BasketCourseNameChangedEvent>
    {
        private IBasketDal _basketDal;
        public BasketCourseNameChangedEventConsumer(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public async Task Consume(ConsumeContext<BasketCourseNameChangedEvent> context)
        {
            var keys = _basketDal.GetKeys();
            if (keys != null) 
            {
                foreach (var key in keys)
                {
                    var basket = await _basketDal.Get(key);
                    basket.BasketItems.ForEach(x =>
                    {
                        x.CourseName = x.CourseId == context.Message.CourseId ? context.Message.UpdatedName : x.CourseName;
                    });
                    await _basketDal.SaveOrUpdate(key, basket);
                }
            }
         

        }
    }
}
