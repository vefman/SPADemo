using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using HomeSecurity.Data.Entity;

namespace HomeSecurity.Data.Repository
{
    public class BaseRepository : IRepository
    {
        public BaseRepository()
        {
            this.DataContext = new HomeSecurityEntities();
        }

        public BaseRepository(HomeSecurityEntities dataContext)
        {
            this.DataContext = new HomeSecurityEntities();
        }        

        public HomeSecurityEntities DataContext
        {
            get;
            set;
        }

        public void SaveChanges()
        {
            this.DataContext.SaveChanges();
        }
    }
}
