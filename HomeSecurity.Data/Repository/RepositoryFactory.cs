using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Data.Repository
{
    public class RepositoryFactory
    {
        public RepositoryFactory()
        {
            DataContext = new HomeSecurityEntities();
        }

        public RepositoryFactory(HomeSecurityEntities dataContext)
        {
            DataContext = dataContext;
        }

        public T CreateRepository<T>() where T : IRepository
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] {this.DataContext}  );
        }

        public HomeSecurityEntities DataContext
        {
            get;
            set;
        }
    }
}
