using ResourceBox.Models;
using ResourceBox.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourceBox.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.UserChats = db.fetchMessages();
            viewModel.UserNotifications = userNotifications;
            return View(viewModel);
        }
        public ActionResult AdvancedBookSearch()
        {
           
                SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.UserChats = db.fetchMessages();
            viewModel.UserNotifications = userNotifications;
            return View(viewModel);


        }
        [HttpPost]
        public ActionResult AdvancedBookSearch(string category,string semester, string department, string subject,string city, string area , string distance)
        {

            return Content(category+semester+department+subject+city+area+distance);
            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            ViewModel viewModel = new ViewModel();
            viewModel.UserChats = db.fetchMessages();
            viewModel.UserNotifications = userNotifications;
            return View(viewModel);


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            SecurityDAO db = new SecurityDAO();
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.AboutUs = db.fetchAbout();
            viewModel.UserChats = db.fetchMessages();
            viewModel.UserNotifications = db.fetchNotification(Convert.ToInt32(Session["userId"]));
            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TermsAndCondition()
        {
            ViewBag.Message = "Terms and Condition";
            SecurityDAO db = new SecurityDAO();
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.UserChats = db.fetchMessages();
            viewModel.UserNotifications = db.fetchNotification(Convert.ToInt32(Session["userId"]));
            viewModel.TermsAndCondition = db.fetchTermsAndCondition();
            return View(viewModel);
        }
    }
}