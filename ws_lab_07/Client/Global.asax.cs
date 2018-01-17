using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Client
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Uri baseAddress = new Uri("http://localhost:59295/Service");
            WebServiceHost svcHost = new WebServiceHost(typeof(Feed1), baseAddress);
            svcHost.Open();
        }
    }
}