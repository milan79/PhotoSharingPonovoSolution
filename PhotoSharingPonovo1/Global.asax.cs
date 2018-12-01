using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSharingPonovo1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exc = Server.GetLastError();
        //    Server.ClearError();
        //    Response.Redirect("/Photo/Index");
        //}
    }
    //public class FilterConfig
    //{
    //    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    //    {
    //        filters.Add(new HandleErrorAttribute());
    //    }
    //}
    
}
