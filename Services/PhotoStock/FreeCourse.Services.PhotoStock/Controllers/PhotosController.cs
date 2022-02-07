using FreeCourse.Services.PhotoStock.Models;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FreeCourse.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomControllerBases
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);

                var returnPath =  photo.FileName;

                PhotoDto photoDto = new() { Url = returnPath };

                return CreateActionResult(Response<PhotoDto>.Success(photoDto, 200));
            }

            return CreateActionResult(Response<PhotoDto>.Fail("photo is empty", 400));
        }
        [HttpDelete]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
            if (!System.IO.File.Exists(path))
            {
                return CreateActionResult(Response<NoContent>.Fail("photo not found", 404));
            }

            System.IO.File.Delete(path);

            return CreateActionResult(Response<NoContent>.Success(204));
        }
    }
}
