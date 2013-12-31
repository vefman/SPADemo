using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeSecurity.Data.Entity;

namespace HomeSecurity.Domain.Data.ViewData
{
    public class BaseMediaViewData
    {
        public BaseMediaViewData()
        {

        }

        public BaseMediaViewData(Medium media, string dropFolder)
        {
            this.ID = media.MediaID;
            this.DateCreated = media.MediaDate;
            this.Description = media.MediaDescription;
            this.Media = Path.Combine(dropFolder, media.MediaName);
            this.MediaType = media.MediaType;
            this.MediaData = media;
        }

        public Medium MediaData
        {
            get;
            set;
        }

        public string MediaType
        {
            get;
            set;
        }

        public Guid ID
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public string Media
        {
            get;
            set;
        }
    }
}