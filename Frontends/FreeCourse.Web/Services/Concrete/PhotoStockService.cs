using FreeCourse.Shared.Dto;
using FreeCourse.Web.Models.PhotoStocks;
using FreeCourse.Web.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Concrete
{
    public class PhotoStockService : IPhotoStockService
    {
        readonly HttpClient _httpClient;

        public PhotoStockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePhoto(string photoUrl)
        {
            var response = await _httpClient.DeleteAsync($"photos?photoUrl={photoUrl}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PhotoStockViewModel> UploadPhoto(IFormFile photo)
        {
            if (photo == null || photo.Length <= 0)
            {
                return null;
            }
            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";
            using var memoryStream = new MemoryStream();
            await photo.CopyToAsync(memoryStream);

            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new ByteArrayContent(memoryStream.ToArray()), "photo", randomFileName);

            var response = await _httpClient.PostAsync("photos", multipartContent);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseData = await response.Content.ReadFromJsonAsync<Response<PhotoStockViewModel>>();
            return responseData.Data;

        }
    }
}
