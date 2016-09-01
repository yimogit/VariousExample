using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcProjectMain.AreasViewEngine
{
    /// <summary>
    /// 自定义视图引擎
    /// </summary>
    /// <remarks>
    /// ViewEngines.Engines.Add(new MvcProjectMain.AreasViewEngine.ThemableRazorViewEngine());
    /// </remarks>
    public class ThemableRazorViewEngine : VirtualPathProviderViewEngine
    {
        //所有区域分离到Modules文件夹,{2}为区域名
        public ThemableRazorViewEngine()
        {
            ViewEngines.Engines.Clear();
            AreaViewLocationFormats = new[]
            {
               "~/Modules/{2}/Views/{1}/{0}.cshtml", 
               "~/Modules/{2}/Views/Shared/{0}.cshtml",
            };

            AreaMasterLocationFormats = new[]
            {
               "~/Modules/{2}/Views/{1}/{0}.cshtml", 
               "~/Modules/{2}/Views/Shared/{0}.cshtml",
            };

            AreaPartialViewLocationFormats = new[]
            {
               "~/Modules/{2}/Views/{1}/{0}.cshtml", 
               "~/Modules/{2}/Views/Shared/{0}.cshtml", 
            };

            ViewLocationFormats = new[]
            {
               "~/Views/{1}/{0}.cshtml", 
               "~/Views/Shared/{0}.cshtml",
            };

            MasterLocationFormats = new[]
            {
               "~/Views/{1}/{0}.cshtml", 
               "~/Views/Shared/{0}.cshtml", 
            };
            PartialViewLocationFormats = new[]
            {
               "~/Views/{1}/{0}.cshtml", 
               "~/Views/Shared/{0}.cshtml", 
            };

            FileExtensions = new[] { "cshtml" };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            string layoutPath = null;
            var runViewStartPages = false;
            IEnumerable<string> fileExtensions = base.FileExtensions;
            return new RazorView(controllerContext, partialPath, layoutPath, runViewStartPages, fileExtensions);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            string layoutPath = masterPath;
            var runViewStartPages = true;
            IEnumerable<string> fileExtensions = base.FileExtensions;
            return new RazorView(controllerContext, viewPath, layoutPath, runViewStartPages, fileExtensions);
        }
    }
}
