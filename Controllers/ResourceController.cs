using ResourceBox.Models;
using ResourceBox.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourceBox.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult ViewBook()
        {
            SecurityDAO dAO = new SecurityDAO();

            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> userNotifications = dAO.fetchNotification(userId);

            List<Book> bookList = dAO.fetchbook();
            List<User> userList = dAO.fetchUser();
            List<Location> locationList = dAO.fetchLocation();
            List<UserChat> userChats = dAO.fetchMessages();
            ViewModel allmodel = new ViewModel();
            allmodel.Books = bookList;
            allmodel.Users = userList;
            allmodel.Locations = locationList;
            allmodel.UserChats = userChats;
            allmodel.UserNotifications = userNotifications;


            NameValueCollection request = Request.Form;

            String department, district, area, minPrice, maxPrice;
            if (!string.IsNullOrEmpty(request["filterSearch"]))
            {
                department = request["department"];
                district = request["district"];
                area = request["area"];
                minPrice = request["minPrice"];
                maxPrice = request["maxPrice"];

                String query = "Select * From Books INNER JOIN Locations ON Books.locationId=Locations.locationId Where ";
                if (!(department == "0" || department == null))
                {
                    query += " department='" + department + "' AND";
                }
                if (!(district == "0" || district == null))
                {
                    query += " city LIKE '%" + district + "%' AND";
                }
                if (!(area == "0" || area == null))
                {
                    query += "  area LIKE '%" + area + "%' OR locationName LIKE '%" + area + "%' AND";
                }
                query += " bookPrice BETWEEN " + minPrice + " AND " + maxPrice;
                bookList = dAO.fetchbook(1, query);
                allmodel.Books = bookList;

                return View(allmodel);
            }


            double lattitude, longitude, selectedDistance, minDistanceLat, minDistanceLong, maxDistanceLat, maxDistanceLong;

            if (!string.IsNullOrEmpty(request["lattitude"]) && !string.IsNullOrEmpty(request["longitude"]) && !string.IsNullOrEmpty(request["distance"]))
            {

                lattitude = Double.Parse(request["lattitude"]);
                longitude = Double.Parse(request["longitude"]);
                selectedDistance = Int32.Parse(request["distance"]);
                minDistanceLat = lattitude - selectedDistance * 0.0125;
                minDistanceLong = longitude - selectedDistance * 0.0125;
                maxDistanceLat = lattitude + selectedDistance * 0.0125;
                maxDistanceLong = longitude + selectedDistance * 0.0125;
                bookList = dAO.fetchbook(minDistanceLat, minDistanceLong, maxDistanceLat, maxDistanceLong);
                //return Content("SELECT Books.bookName from Books INNER JOIN Locations ON Books.locationId=Locations.locationId WHERE lattitude>=" + lattitude + " AND lattitude<=" + maxDistanceLat + " AND longitude>=" + longitude + " AND longitude<=" + maxDistanceLong);
                allmodel.Books = bookList;
                allmodel.Users = userList;
                return View(allmodel);

            }
            string search;

            if (!string.IsNullOrEmpty(request["search"]))
            {
                search = request["search"];
                bookList = dAO.fetchbook(search);
                allmodel.Books = bookList;
                allmodel.Users = userList;
                return View(allmodel);
            }
            return View(allmodel);
        }
        public ActionResult ViewDetails(int bookId)
        {
            int userId = Convert.ToInt32(Session["userId"]);
            SecurityDAO db = new SecurityDAO();
            ViewModel viewModel = new ViewModel();
            viewModel.UserNotifications = db.fetchNotification(userId);
            viewModel.Books = db.fetchbook(bookId);
            viewModel.Users = db.fetchUser();
            viewModel.Locations = db.fetchLocation();
            viewModel.UserChats = db.fetchMessages();

           
            return View(viewModel);

        }

        public ActionResult ViewPost(String postType)
        {

            int userId = Convert.ToInt32(Session["userId"]);
            SecurityDAO db = new SecurityDAO();
            ViewModel viewModel = new ViewModel();
            viewModel.UserNotifications = db.fetchNotification(userId);
            viewModel.Users = db.fetchUser();
            viewModel.Locations = db.fetchLocation();
            viewModel.UserChats = db.fetchMessages();
            if (postType==null || postType == "") 
            {
                ViewBag.postType = "All Posts";
                viewModel.Posts = db.fetchPost();
            }
            else
            {
                ViewBag.postType = postType;
                viewModel.Posts = db.fetchPost().Where(i => i.postType == postType);
            }
            return View(viewModel);

        }



    }

 }