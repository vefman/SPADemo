using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HomeSecurity.Data.Entity;

namespace HomeSecurity.Data.Repository
{
    public class AppSettingRepository : BaseRepository
    {
        public AppSettingRepository()
            : base()
        {

        }

        public AppSettingRepository(HomeSecurityEntities dataContext)
            : base(dataContext)
        {

        }

        public string GetAppSetting(string settingName)
        {
            string result = null;

            AppSetting value = DataContext.AppSettings.SingleOrDefault(a => a.SettingName == settingName);

            if (value != null)
            {
                result = value.SettingValue;
            }

            return result;
        }
    }
}
