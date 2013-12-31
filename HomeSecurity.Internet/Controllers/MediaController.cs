using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;

using Newtonsoft.Json.Linq;

using HomeSecurity.Domain.Data.ViewData;
using HomeSecurity.Domain.Helper.Home;

namespace HomeSecurity.Internet.Controllers
{
    public class MediaController : BaseApiController
    {        
        public HttpResponseMessage Delete(params string[] media)
        {
            HomeHelper homeHelper = new HomeHelper(this.DataContext);

            foreach (string m in media)
            {
                string[] val = m.Split(';');

                Guid id = Guid.Parse(val[0]);
                string path = val[1];

                homeHelper.DeleteMedia(id);

                string filePath = HttpContext.Current.Server.MapPath(path);

                File.Delete(filePath);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage Put([FromBody]JObject json)
        {
            Guid id = Guid.Parse(json["id"].ToString());
            String description = json["description"].ToString();

            HomeHelper homeHelper = new HomeHelper(this.DataContext);

            homeHelper.EditMedia(id, description);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
