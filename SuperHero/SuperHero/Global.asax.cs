using SuperHero.Domain.AutoMapperConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SuperHero
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(config: cfg => cfg.AddProfile<AutoMapperProfile>());
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            ErrorConfig.Handle(Context);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class ErrorConfig
    {
        public static void Handle(HttpContext context)
        {
            switch (context.Response.StatusCode)
            {
                //Not authorized
                case 401:
                    Show(context, 401);
                    break;

                //Not found
                case 404:
                    Show(context, 404);
                    break;
            }
        }

        static void Show(HttpContext context, Int32 code)
        {
            context.Response.Clear();

            var w = new HttpContextWrapper(context);
            var c = new Controllers.ErrorController() as IController;
            var rd = new RouteData();

            rd.Values["controller"] = "Error";
            rd.Values["action"] = "Index";
            rd.Values["id"] = code.ToString();

            c.Execute(new RequestContext(w, rd));
        }
    }
}
