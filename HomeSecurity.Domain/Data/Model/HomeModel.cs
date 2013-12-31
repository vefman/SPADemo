using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeSecurity.Domain.Data.Model
{
    public class HomeModel
    {
        public IEnumerable<ViewData.PictureViewData> Pictures { get; set; }
        public IEnumerable<ViewData.VideoViewData> Videos { get; set; }
    }
}
