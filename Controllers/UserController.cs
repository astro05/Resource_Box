using ResourceBox.Models;
using ResourceBox.Services.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourceBox.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult UserProfile(int UserId,string email)
        {
            ViewBag.LoginSuccess = Convert.ToString(Session["LoginSuccess"]);
            SecurityDAO db = new SecurityDAO();
            int userId = UserId;
            List<User> users= db.fetchUser(userId);
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            ViewModel viewModel = new ViewModel();
            viewModel.UserNotifications = userNotifications;
            viewModel.UserChats = db.fetchMessages();
            viewModel.Users = users;
            Session["LoginSuccess"] = null;
            return View(viewModel);
        }
        public ActionResult PostStatus()
        {

            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            List<Post> posts = db.fetchPost();
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.UserChats = db.fetchMessages();
            viewModel.UserNotifications = userNotifications;
            viewModel.Posts = posts;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult PostStatus(String Post, HttpPostedFileBase file, HttpPostedFileBase image,String postType,String privacy)
        {

            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            String path = null;
            if(file!=null)
            { 
             path = Path.Combine(Server.MapPath("~/Media/Files"),
                                                Path.GetFileName(file.FileName));
            file.SaveAs(path);
            }

            if (image != null)
            {
                path = Path.Combine(Server.MapPath("~/Media/Images/Posts"),
                                               Path.GetFileName(image.FileName));
                image.SaveAs(path);
            }


            Post post = new Post();
            post.post = Post;
            if (image != null)
            {
                post.postImage = "~/Media/Images/Posts/"+image.FileName;
            }
            if (file != null)
            {
                post.file= "~/Media/Files/" + file.FileName;
            }
            post.postType = postType;
            post.privacy = privacy;
            post.userId = userId;
            post.date_time = Convert.ToString(DateTime.Now);
            db.addPost(post);
            List<Post> posts = db.fetchPost();
            
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.UserNotifications = userNotifications;
            viewModel.Posts = posts;
            viewModel.UserChats = db.fetchMessages();
            return View(viewModel);
        }
        public ActionResult PostBook()
        {
           
            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            ViewModel viewModel = new ViewModel();
            viewModel.UserNotifications = userNotifications;
            viewModel.Users = db.fetchUser();
            viewModel.Books = db.fetchbook();
            viewModel.UserChats = db.fetchMessages();
            return View(viewModel);

        }


        [HttpPost]
        public ActionResult PostBook(HttpPostedFileBase image)
        {
            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> userNotifications = db.fetchNotification(userId);
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.UserNotifications = userNotifications;
            viewModel.Books = db.fetchbook();
            viewModel.UserChats = db.fetchMessages();


            NameValueCollection request = Request.Form;
            string bookName, bookAuthor, releaseDate, price, category,department,locationName,lattitude,longitude;
            ViewBag.verification = false;
            if (!string.IsNullOrEmpty(request["name"]) && !string.IsNullOrEmpty(request["author"]) && !string.IsNullOrEmpty(request["category"]) && image != null && image.ContentLength > 0)
            {
                bookName = request["name"];
                bookAuthor = request["author"];
                releaseDate = request["release_date"];
                price = request["price"];
                category = request["category"];
                department = request["department"];
                locationName = request["location"];
                lattitude = request["lattitude"];
                longitude = request["longitude"];

               

                try
                {
                    SecurityDAO dao = new SecurityDAO();

                    string path = Path.Combine(Server.MapPath("~/Media/Images/Books"),
                                               Path.GetFileName(image.FileName));
                    image.SaveAs(path);


                    string[] spllitedArea = locationName.Split(',');
                    String country = spllitedArea[spllitedArea.Length - 1];
                    String city = spllitedArea[spllitedArea.Length - 2];
                    String area = spllitedArea[spllitedArea.Length - 3];
                   

                    Location location = new Location();
                    location.locationName = locationName;
                    location.lattitude = lattitude;
                    location.longitude = longitude;
                    location.area = area;
                    location.city = city;
                    location.country = country;
                   
                    int id=dao.addLocation(location);


                    Book book = new Book();
                    book.bookName = bookName;
                    book.bookAuthor = bookAuthor;
                    book.bookPrice = Int32.Parse(price);
                    book.bookCategory = category;
                    book.department = department;
                    book.releaseDate = releaseDate;
                    book.bookImage = "~/Media/Images/Books/"+image.FileName;
                    book.userIdFK = Convert.ToInt32(Session["userId"]);
                    book.locationIdFK = id;
                    
                    dao.addBook(book);
                    ViewBag.postSuccess = true;
                    viewModel.Books = db.fetchbook();
                    return View(viewModel);
                }
                catch (Exception ex)
                {
                    ViewBag.postFailed = true;
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    ViewBag.Alert = "Wrong Input Field";
                    return View(viewModel);
                }
            }
          
            else
            {
                ViewBag.Alert = "Fields are empty";
                ViewBag.postFailed = true; 
                return View(viewModel);
            }
            
        }
        [HttpPost]
        public ActionResult DeleteBook(int bookId)
        {
            SecurityDAO db = new SecurityDAO();
            db.deleteBook(bookId);
            return RedirectToAction("PostBook","User");
        }
        public ActionResult UserMessage()
        {
            ViewBag.list = new ArrayList();
            ViewBag.javaScriptLoaded = false;
            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> currentUserNotifications = db.fetchNotification(userId);
            List<UserChat> userChats = db.fetchMessages();
            ViewModel allmodel = new ViewModel();
            allmodel.UserChats = userChats;
            allmodel.UserNotifications = currentUserNotifications;
            allmodel.Users = db.fetchUser();
            allmodel.UserChats = db.fetchMessages();
            db.updateNotifcation(userId, 0);
            return View(allmodel);
        }
        [HttpPost]
        public ActionResult UserMessage(int SenderId,int RecieverId,String message,int reloadState,int SelectedId)
        {
            //return Content(Convert.ToString(SenderId) + Convert.ToString(RecieverId) + message + Convert.ToString(reloadState) + Convert.ToString(SelectedId));
            /*
            String messegeSend="";
            NameValueCollection request = Request.Form;
            if (!string.IsNullOrEmpty(request["message"]) )
            {
                messegeSend= request["message"];
            }
            return Content(message);
             return Content(Convert.ToString(SenderId)+ Convert.ToString(RecieverId));
            */
            ViewBag.list = new ArrayList();
            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            List<UserNotification> currentUserNotifications = db.fetchNotification(userId);
            List<UserChat> userChats = db.fetchMessages();
            ViewModel allmodel = new ViewModel();
            
            if(reloadState==1)
            {
                ViewBag.javaScriptLoaded = true;
                ViewBag.SenderId = SelectedId;
                allmodel.UserChats = userChats;
                allmodel.Users = db.fetchUser();
                allmodel.UserNotifications = currentUserNotifications;
                db.updateNotifcation(userId, 0);
                db.updateSeenHistory(userId, SelectedId);
                return View(allmodel);
            }


           
            ViewBag.javaScriptLoaded = false;
           
            currentUserNotifications = db.fetchNotification(userId);
            UserChat userChat = new UserChat();
            userChat.senderId = Convert.ToInt32(Session["userId"]);
            userChat.message = message;
            userChat.recieverId = RecieverId;
            userChat.date_time = Convert.ToString(DateTime.Now);
            db.addChat(userChat);

            List<UserNotification> userNotifications = db.fetchNotification(RecieverId);
            int messageUnread=userNotifications[0].messageUnread;
            messageUnread++;
            db.updateNotifcation(RecieverId, messageUnread);

            userChats = db.fetchMessages();
            allmodel = new ViewModel();
            allmodel.Users = db.fetchUser();
            allmodel.UserChats = userChats;
            allmodel.UserNotifications = currentUserNotifications;
            return View(allmodel);
            

        }
        
        
        public ActionResult CheckUserHasNewAlert()
        {
            String messageUnread="0";
            SecurityDAO db = new SecurityDAO();
            int userId = Convert.ToInt32(Session["userId"]);
            if(userId!=0)
            {
                List<UserNotification> userNotifications = db.fetchNotification(userId);

                messageUnread = Convert.ToString(userNotifications[0].messageUnread);
            }
            
               
           return Content(messageUnread) ;
        }
        public ActionResult UserDashboard()
        {
            SecurityDAO db = new SecurityDAO();
            ViewModel viewModel = new ViewModel();
            viewModel.Users = db.fetchUser();
            viewModel.UserNotifications = db.fetchNotification(Convert.ToInt32(Session["userId"]));
            viewModel.UserChats = db.fetchMessages();
            viewModel.Posts = db.fetchPost();
            ViewBag.postCount = 0;
            foreach (var x in viewModel.Posts.Where(i => i.userId == Convert.ToInt32(Session["userId"])))
            {
                ViewBag.postCount += 1;
            }
            return View(viewModel);
        }
    }
}