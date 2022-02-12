using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Shared.Messages
{
    public class BasketCourseNameChangedEvent
    {
        public string UserId { get; set; }

        public string CourseId { get; set; }
        public string UpdatedName { get; set; }
    }
}
