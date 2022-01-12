using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace SpecFlowProject1.Helper
{
    class BaseHelper
    {
        public readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["CRM_Admin"].ToSecureString();
        public readonly SecureString _approver = System.Configuration.ConfigurationManager.AppSettings["CRM_Approver"].ToSecureString();
        public readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["CRM_AdminPassword"].ToSecureString();
        public readonly SecureString _approverPwd = System.Configuration.ConfigurationManager.AppSettings["CRM_ApproverPassword"].ToSecureString();
        public WebClient client;
        public XrmApp xrmApp;
    }
}
