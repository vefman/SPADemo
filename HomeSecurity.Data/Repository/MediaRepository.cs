using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Data.Repository
{
    public class MediaRepository : BaseRepository
    {
        public MediaRepository() : base()
        {
           
        }

        public MediaRepository(HomeSecurityEntities dataContext)
            : base(dataContext)
        {

        }

        public Medium GetMedia(Guid id)
        {
            return this.DataContext.Media.SingleOrDefault(m => m.MediaID == id);
        }

        public void DeleteMedia(Medium media)
        {
            this.DataContext.Media.DeleteObject(media);
        }
    }
}
