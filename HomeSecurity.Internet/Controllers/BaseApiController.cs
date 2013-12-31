using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Internet.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {
            this.DataContext = new HomeSecurityEntities();
        }        

        public HomeSecurityEntities DataContext
        {
            get;
            set;
        }
    }
}
