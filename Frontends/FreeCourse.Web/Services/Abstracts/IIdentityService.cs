using FreeCourse.Shared.Dto;
using FreeCourse.Web.Models;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
   public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
