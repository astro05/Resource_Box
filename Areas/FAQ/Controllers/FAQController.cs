using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ResourceBox.Areas.FAQ.Controllers
{
    [RouteArea("FAQ")]
    public class FAQController : Controller
    {
        // GET: FAQ/FAQ
        public ActionResult FAQ()

        {


            return View();
        }
    }
}