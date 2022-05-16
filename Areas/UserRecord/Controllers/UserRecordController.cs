using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ResourceBox.Models;
using ResourceBox.Services.Data;

namespace ResourceBox.Areas.UserRecord.Controllers
{
    [RouteArea("UserRecord")]
    public class UserRecordController : Controller
    {
        // GET: UserRecord/UserRecord
        public ActionResult UserRecord()
        {
            SecurityDAO db = new SecurityDAO();
            
                List<User> empList = db.fetchUser();
            ViewModel viewModel = new ViewModel();
            viewModel.Users = empList;

            return View(viewModel);
        }


        public ActionResult GetData()
        {
            SecurityDAO db = new SecurityDAO();

            List<User> empList = db.fetchUser();
            ViewModel viewModel = new ViewModel();
            viewModel.Users = empList;
            return View(viewModel);
           

        }
        [HttpPost]
        public ActionResult DeleteData(int userId)
        {
            
            SecurityDAO db = new SecurityDAO();
            db.DeleteUser(userId);
            List<User> empList = db.fetchUser();
            ViewModel viewModel = new ViewModel();
            viewModel.Users = empList;
            return View(viewModel);


        }

        public ActionResult Test()
        {
            int userId = 14;
            SecurityDAO db = new SecurityDAO();
            db.DeleteUser(userId);



            return Content("True");


        }





    }
}