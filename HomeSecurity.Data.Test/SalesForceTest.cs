using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HomeSecurity.Data.Common;
using HomeSecurity.Data.Repository;
using HomeSecurity.Data.Entity;
using HomeSecurity.Data.Entity.SalesForce;

namespace HomeSecurity.Data.Test
{
    [TestClass]
    public class SalesForceTest
    {
        [TestMethod]
        public void SalesForceRepository_GetAllContacts_Test()
        {
            RepositoryFactory repFactory = new RepositoryFactory();

            AppSettingRepository appSettingsRep = repFactory.CreateRepository<AppSettingRepository>();

            SalesforceRepository sfRep = repFactory.CreateRepository<SalesforceRepository>();

            Credentials credentials = new Credentials()
            {
                UserName = appSettingsRep.GetAppSetting(AppSettings.SalesForceUserName),
                Password = appSettingsRep.GetAppSetting(AppSettings.SalesForcePassword),
                SecurityToken = appSettingsRep.GetAppSetting(AppSettings.SalesForceSecurityToken)
            };

            IList<ContactEntity> target = sfRep.GetAllContacts(credentials);

            Assert.IsNotNull(target);
            Assert.IsTrue(target.Count > 0);
        }
    }
}
