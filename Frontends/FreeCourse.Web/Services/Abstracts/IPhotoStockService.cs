using FreeCourse.Web.Models.PhotoStocks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
    public interface IPhotoStockService
    {
        Task<PhotoStockViewModel> UploadPhoto(IFormFile formFile);
        Task<bool> DeletePhoto(string photoUrl);
    }
}
