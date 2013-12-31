using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HomeSecurity.Data.SalesForce;

namespace HomeSecurity.Data.Helper
{
    public class SalesForceHelper
    {
        public string SessionID { get; set; }
        public string ServerUrl { get; set; }        

        public SalesForceHelper()
        {            
        }

        public bool Login(string username, string password, string securityToken)
        {
            try
            {
                using (SalesForce.SforceService service = new SalesForce.SforceService())
                {
                    LoginResult loginResult =
                        service.login(username, String.Concat(password, securityToken));
                        
                    this.SessionID = loginResult.sessionId;
                    this.ServerUrl = loginResult.serverUrl;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    } 
}
