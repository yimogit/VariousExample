using System.Web.Mvc;

namespace CommonAreasProject
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CommonAreasProject";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CommonAreasProject",
                "CommonAreasProject/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, },
                namespaces: new string[] { "CommonAreasProject.Controllers" }
            );
        }
    }
}
