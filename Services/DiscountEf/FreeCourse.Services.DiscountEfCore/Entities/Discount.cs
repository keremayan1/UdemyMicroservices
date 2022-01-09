using System;
using FreeCourse.Core.Entities.EntityFramework;

namespace FreeCourse.Services.DiscountEfCore.Entities
{
    public class Discount:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string DiscountCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
