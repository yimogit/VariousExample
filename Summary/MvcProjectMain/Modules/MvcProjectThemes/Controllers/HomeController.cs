using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectThemes.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Theme/

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TestPartial(string str)
        {
            ViewBag.TempStr = str;
            return PartialView("_HtmlRenderActionPartial");
        }
    }
}
