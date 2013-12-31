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
    public class VideoController : BaseApiController
    {
        // GET api/video
        public IEnumerable<VideoViewData> Get(int skip, int count)
        {
            HomeHelper homeHelper = new HomeHelper(this.DataContext);

            return homeHelper.GetVideos(skip, count);
        }

        // GET api/video/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/video
        public void Post([FromBody]string value)
        {
        }

        // PUT api/video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/video/5
        public void Delete(int id)
        {
        }
    }
}
