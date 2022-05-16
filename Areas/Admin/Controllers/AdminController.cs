using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResourceBox.Models;
using ResourceBox.Services.Data;

namespace ResourceBox.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Admin()
        {
            SecurityDAO db = new SecurityDAO();
            ViewBag.MemberCount = db.UserCount();
            ViewBag.PostCount = db.postCount();



            return View();
        }

    




    }
}