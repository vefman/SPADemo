using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HomeSecurity.Domain.Data.ViewData;
using HomeSecurity.Domain.Helper.Home;

namespace HomeSecurity.Internet.Controllers
{
    public class PictureController : BaseApiController
    {     
        public IEnumerable<PictureViewData> Get(int skip, int count)
        {
            HomeHelper homeHelper = new HomeHelper(this.DataContext);

            return homeHelper.GetPictures(skip, count);
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(string id)
        {            

        }
    }
}