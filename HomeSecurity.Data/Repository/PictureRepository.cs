using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Data.Repository
{
    public class PictureRepository : BaseRepository
    {
        public PictureRepository() : base()
        {
           
        }

        public PictureRepository(HomeSecurityEntities dataContext)
            : base(dataContext)
        {

        }

        public IQueryable<Medium> GetPictures()
        {
            return this.DataContext.Media.Where(p => p.MediaType == "P");
        }

        public void AddPicture(Medium picture)
        {
            this.DataContext.Media.AddObject(picture);
        }
    }
}
