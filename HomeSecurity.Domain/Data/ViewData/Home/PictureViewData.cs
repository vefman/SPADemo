using System;
using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HomeSecurity.Data.Entity;

namespace HomeSecurity.Domain.Data.ViewData
{
    public class PictureViewData : BaseMediaViewData
    {
        public PictureViewData(Medium media, string dropFolder)
            :base(media, dropFolder)
        {
            
        }  
      

    }
}