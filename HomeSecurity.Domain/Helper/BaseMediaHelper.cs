using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

using HomeSecurity.Data.Entity;
using HomeSecurity.Data.Common;
using HomeSecurity.Data.Repository;

using HomeSecurity.Domain.Data.Model;
using HomeSecurity.Domain.Data.ViewData;

namespace HomeSecurity.Domain.Helper
{
    public class BaseMediaHelper : BaseHelper
    {
        private AppSettingRepository _appSettings;

        public BaseMediaHelper(HomeSecurityEntities dataContext)
            :base(dataContext)
        {
            _appSettings = RepositoryFactory.CreateRepository<AppSettingRepository>();

            this.VideoDropFolder = _appSettings.GetAppSetting(AppSettings.VideoDropFolder);
            this.PictureDropFolder = _appSettings.GetAppSetting(AppSettings.PictureDropFolder);
        }

        public string VideoDropFolder
        {
            get;
            set;
        }

        public string PictureDropFolder
        {
            get;
            set;
        }
    }
}
