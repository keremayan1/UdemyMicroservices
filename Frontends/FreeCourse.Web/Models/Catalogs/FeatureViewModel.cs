﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Display(Name ="Kurs Süre")]
        public int Duration { get; set; }
    }
}
