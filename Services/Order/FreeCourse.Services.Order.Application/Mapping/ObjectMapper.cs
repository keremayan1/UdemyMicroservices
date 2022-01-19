using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace FreeCourse.Services.Order.Application.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cgf =>
            {
                cgf.AddProfile<CustomMapping>();

            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;
    }
}
