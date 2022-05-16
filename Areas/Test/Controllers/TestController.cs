using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourceBox.Areas.Test.Controllers
{
    [RouteArea("Test")]
    public class TestController : Controller
    {
        // GET: Test/Test
        public ActionResult Test()
        {
            return View();
        }
    }
}