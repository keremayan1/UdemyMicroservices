using System.Threading.Tasks;
using FreeCourse.Services.Product.Business.Abstract;
using FreeCourse.Services.Product.Entities;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomControllerBases
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Entities.Product product)
        {
            var result = await _productService.AddAsync(product);
            return CreateActionResult(result);
        }
        [HttpPost("add2")]
        public  IActionResult Add2(Entities.Product product)
        {
            var result =  _productService.Add(product);
            return CreateActionResult(result);
        }
    }
}
