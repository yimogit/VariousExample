using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac.Configuration;
using System.Reflection;
using Example.Logging;
using Example.Core;
namespace WebApiDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterType<FileLogger>();
            builder.Register<ILogger>(c => c.Resolve<FileLogger>()).InstancePerLifetimeScope();
            builder.RegisterType<RedisManager>();
            builder.Register<ICacheManager>(c => c.Resolve<RedisManager>()).InstancePerLifetimeScope();//需要再web.config配置redis连接字符串

            //注册mvc控制器
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region 注册webapi控制器
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //可直接搜索Autofac.WebApi2 若遇到安全隐患问题(不是webapi2.2 host2.0)。则需要安装WebApi2.0, Host2.0 
            HttpConfiguration config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}