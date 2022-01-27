using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
  public  interface IClientCridentialTokenService
    {
        Task<string> GetToken();
    }
}
