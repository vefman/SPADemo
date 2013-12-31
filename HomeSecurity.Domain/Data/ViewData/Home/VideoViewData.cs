using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Domain.Data.ViewData
{
    public class VideoViewData : BaseMediaViewData
    {
        public VideoViewData(Medium media, string dropFolder)
            :base(media, dropFolder)
        {
            Medium poster = media.Media1.SingleOrDefault(m => m.MediaType == "R");

            if(poster != null)
            {                
                this.Poster = Path.Combine(dropFolder, poster.MediaName);
            }
        }

        public string Poster
        {
            get;
            set;
        }
    }
}