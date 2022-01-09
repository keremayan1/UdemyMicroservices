
using System.ComponentModel.DataAnnotations;
using FreeCourse.Core.Entities.EntityFramework;

namespace FreeCourse.Services.Product.Entities
{
    public class Product: IEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
