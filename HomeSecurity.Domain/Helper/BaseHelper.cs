using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HomeSecurity.Data.Entity;
using HomeSecurity.Data.Repository;

namespace HomeSecurity.Domain.Helper
{
    public class BaseHelper
    {        
        public BaseHelper(HomeSecurityEntities dataContext)
        {
            this.DataContext = dataContext;
            this.RepositoryFactory = new RepositoryFactory(dataContext);
        }

        protected RepositoryFactory RepositoryFactory
        {
            get;
            set;
        }

        protected HomeSecurityEntities DataContext
        {
            get;
            set;
        }        
    }
}
