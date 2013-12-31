using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;

using HomeSecurity.Domain.Data.ViewData;
using HomeSecurity.Domain.Helper.Home;

namespace HomeSecurity.Internet.Controllers
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return name.Replace("\"", string.Empty); 
        }
    }

    public class UploadController : BaseApiController
    {
        private const string folderName = "~/Drop";
        private const string picFolderName = "~/Drop/Pictures";
        private const string videoFolderName = "~/Drop/Videos";

        public Task<IEnumerable<BaseMediaViewData>> Post()
        {
            HomeHelper homeHelper = new HomeHelper(this.DataContext);

            List<BaseMediaViewData> result = new List<BaseMediaViewData>();

            if (Request.Content.IsMimeMultipartContent())
            {
                var PATH = HttpContext.Current.Server.MapPath(folderName);

                var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
               
                var streamProvider = new CustomMultipartFormDataStreamProvider(PATH);

                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IEnumerable<BaseMediaViewData>>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    }

                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        string dropFolder = HttpContext.Current.Server.MapPath(folderName);
                        string location = null;
                        BaseMediaViewData mediaViewData = null;

                        if (info.Name.EndsWith(".jpg"))
                        {                            
                            location = HttpContext.Current.Server.MapPath(picFolderName) + "/" + info.Name;

                            if (File.Exists(location))
                            {
                                File.Delete(location);
                            }

                            File.Move(dropFolder + "/" + info.Name, location);

                            mediaViewData = homeHelper.AddPicture(info.Name, null);
                        }
                        else if (info.Name.EndsWith(".mp4"))
                        {
                            location = HttpContext.Current.Server.MapPath(videoFolderName) + "/" + info.Name;

                            if(File.Exists(location))
                            {
                                File.Delete(location);
                            }

                            File.Move(dropFolder + "/" + info.Name, location);

                            mediaViewData = homeHelper.AddVideo(info.Name, null, null, null);
                        }

                        return mediaViewData;
                    });

                    return fileInfo;
                });

                return task;               
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }
    }
}
