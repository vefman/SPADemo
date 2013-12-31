using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Data.Repository
{
    public class VideoRepository : BaseRepository
    {
        public VideoRepository() : base()
        {
           
        }

        public VideoRepository(HomeSecurityEntities dataContext)
            : base(dataContext)
        {

        }

        public IQueryable<Medium> GetVideos()
        {
            return this.DataContext.Media.Where(v => v.MediaType == "V");
        }

        public void AddVideo(Medium media)
        {
            this.DataContext.Media.AddObject(media);
        }
    }
}
