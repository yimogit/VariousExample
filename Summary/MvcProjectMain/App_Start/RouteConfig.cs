using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcProjectMain.RouteExtensions;

namespace MvcProjectMain
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapAreaRoute( //在最前面注册，或者使用AdminAreaRegistration + AreaRegistration.RegisterAllAreas();注册
            //    "CommonAreasProject",
            //    routes.MapRoute(
            //        name: "CommonAreasProject/Home/Index",
            //        url: "CommonAreasProject/{controller}/{action}/{id}",
            //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //        namespaces: new string[] { "CommonAreasProject.Controllers" }
            //    )
            //);
            //域名需要再iis、host中配置，线上解析到主机即可。

            routes.MapAreaRoute(
                "MvcProjectThemes",
                routes.MapRouteDomain(
                    name: "Theme/Home/Index",
                    domain: "www.site1.dev",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new string[] { "MvcProjectThemes.Controllers" }
                )
            );

            routes.MapRouteDomain(
                name: "Main/Home/Index",
                domain: "www.main.dev",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcProjectMain.Controllers" }
            );

        }

    }
}