using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HomeSecurity.Data.Helper;
using HomeSecurity.Data.Entity;
using HomeSecurity.Data.Entity.SalesForce;
using HomeSecurity.Data.SalesForce;

namespace HomeSecurity.Data.Repository
{
    public class SalesforceRepository : BaseRepository, IDisposable
    {
        SalesForceHelper _sfHelper = new SalesForceHelper();
        SforceService _sfClient = new SforceService();

        public SalesforceRepository() : base()
        {
               
        }

        public SalesforceRepository(HomeSecurityEntities dataContext)
            : base(dataContext)
        {
            
        }

        private List<T> Query<T>(string soql) where T : sObject, new()
        {
            List<T> returnList = new List<T>();

            SetupService();

            QueryResult results = _sfClient.query(soql);

            for (int i = 0; i < results.size; i++)
            {
                T item = results.records[i] as T;

                if (item != null)
                    returnList.Add(item);
            }

            return returnList;
        }

        public IList<ContactEntity> GetAllContacts(Credentials credentials)
        {
            List<ContactEntity> result = new List<ContactEntity>();

            if (_sfHelper.Login(credentials.UserName, credentials.Password, credentials.SecurityToken))
            {
                string soql = @"SELECT c.ID, c.FirstName, c.LastName FROM Contact c";

                List<Contact> sfContacts = Query<Contact>(soql);

                foreach (Contact sfContact in sfContacts)
                {
                    ContactEntity contact = new ContactEntity(sfContact);

                    result.Add(contact);
                }
            }

            return result;
        }

        public IEnumerable<AccountEntity> GetAllAccounts(Credentials credentials)
        {
            if (_sfHelper.Login(credentials.UserName, credentials.Password, credentials.SecurityToken))
            {

            }

            return null;
        }

        public IEnumerable<CaseEntity> GetAllCases(Credentials credentials)
        {
            if (_sfHelper.Login(credentials.UserName, credentials.Password, credentials.SecurityToken))
            {

            }

            return null;
        }

        private void SetupService()
        {
            _sfClient.SessionHeaderValue =
                new SessionHeader() { sessionId = _sfHelper.SessionID };            

            _sfClient.Url = _sfHelper.ServerUrl;
        }

        public void Dispose()
        {
            _sfClient.Dispose();
        }
    }
}
