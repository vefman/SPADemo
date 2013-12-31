using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Internet.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
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
