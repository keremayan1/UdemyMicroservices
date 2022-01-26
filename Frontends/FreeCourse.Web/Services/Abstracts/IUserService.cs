﻿using FreeCourse.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
  public  interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
