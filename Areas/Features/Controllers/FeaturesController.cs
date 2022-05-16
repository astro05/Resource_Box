using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResourceBox.Models;
using ResourceBox.Services.Data;

namespace ResourceBox.Areas.Features.Controllers
{
    public class FeaturesController : Controller
    {
        // GET: Features/Features
        public ActionResult Features()
        {
            SecurityDAO db = new SecurityDAO();
            ViewBag.MemberCount = db.UserCount();
            ViewBag.PostCount = db.postCount();


            return View();
        }
    }
}