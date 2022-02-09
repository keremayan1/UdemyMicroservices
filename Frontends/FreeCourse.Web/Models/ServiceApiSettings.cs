using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public string PhotoStockUri { get; set; }
        public ServiceAPI Catalog { get; set; }
        public ServiceAPI PhotoStock { get; set; }
        public ServiceAPI Basket { get; set; }
        public ServiceAPI Discount { get; set; }
        public ServiceAPI Payment { get; set; }
        public ServiceAPI Order { get; set; }
    }
    public class ServiceAPI
    {
        public string Path { get; set; }
    }
}
