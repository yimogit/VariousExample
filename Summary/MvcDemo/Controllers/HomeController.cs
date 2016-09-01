using Example.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        //属性注入
        public ILogger Logger { get; set; }

        private readonly ILogger _Logger;
        public HomeController(ILogger logger)
        {
            _Logger = logger;
        }

        public ActionResult Index()
        {
            _Logger.Info("使用autofac通过构造函数注入Logger并在Mvc中写入日志");
            return Content("使用autofac通过构造函数注入Logger并在Mvc中写入日志成功");
        }
        public ActionResult Index2()
        {
            Logger.Info("使用autofac通过属性注入Logger并在Mvc中写入日志");
            return Content("使用属性注入，注册师调用builder.RegisterControllers(assembly).PropertiesAutowired();");
        }

    }
}
