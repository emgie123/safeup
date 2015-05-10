using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SafeUp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // ViewEngines.Engines.Add(new MyCustomViewLocations());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
