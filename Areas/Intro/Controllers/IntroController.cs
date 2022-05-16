using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourceBox.Areas.Intro.Controllers
{[RouteArea("Intro")]
    public class IntroController : Controller
    {
        // GET: Intro/Intro
        public ActionResult Intro_Index()
        {
            return View();
        }

        public ActionResult Intro_loading()
        {
            return View();
        }

    }
}