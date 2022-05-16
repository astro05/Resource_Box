using ResourceBox.Models;
using ResourceBox.Services.Data;
using ResourceBox.Services.Operation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourceBox.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            NameValueCollection request = Request.Form;
            string email, password;
            String key = "GIVENHASHCODE";
            ViewBag.verification = false;
            if (!string.IsNullOrEmpty(request["email"]) && !string.IsNullOrEmpty(request["password"]))
            {
                email = request["email"];
                password = request["password"];
                User user = new User();
                user.email = email;
                user.password = password;
                SecurityServices service = new SecurityServices();
                SecurityDAO dao = new SecurityDAO();
                if (!string.IsNullOrEmpty(dao.getHash(user)))
                    key = dao.getHash(user);
                user.password = service.EncryptPassword(key, password);

                if (service.Authenticate(user))
                {
                    List<User> userList = dao.fetchUser(email);

                    Session["user"] = userList[0].userName;
                    Session["userId"] = userList[0].userId;
                    Session["email"] = userList[0].email;
                    Session["LoginSuccess"] = "true";
                    return RedirectToAction("UserProfile", "User", new { UserId = userList[0].userId, Email = user.email });
                }
                else
                {
                    ViewBag.verification = true;
                    return View();
                }
            }


            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }
        public ActionResult Registration()
        {

            NameValueCollection request = Request.Form;
            string name, email, phone, password;
            ViewBag.verification = false;
            if (!string.IsNullOrEmpty(request["username"]) && !string.IsNullOrEmpty(request["phone"]) && !string.IsNullOrEmpty(request["password"]))
            {
                name = request["username"];
                email = request["email"];
                phone = request["phone"];
                password = request["password"];


                User user = new User();
                user.userName = name;
                user.email = email;
                user.phone = phone;
                user.password = password;
                SecurityDAO db = new SecurityDAO();
                SecurityServices service = new SecurityServices();
                var keyNew = EncryptedSecurity.GeneratePassword(10);
                user.hashCode = keyNew;
                user.password = service.EncryptPassword(keyNew, password);

                if (service.Authenticate(user))
                {
                    ViewBag.verification = true;
                    return View();
                }
                else
                {
                    db.createUser(user);
                    return RedirectToAction("OTPVerification", "Authentication", new { Email = user.email });
                    //return Content("Success");
                }
            }

            return View();
        }

        public ActionResult OTPVerification(String Email)
        {

            ViewBag.Email = Email;
            SecurityDAO db = new SecurityDAO();
           
            Random rnd = new Random();
            int otp = rnd.Next(100000, 999999);
            db.updateOTP(Email, Convert.ToString(otp), "False");
            string msg = "Your otp from www.ResourceBox.Com/BD is " + otp + ". Dont Share Your OTP with Anyone. ";
            bool otpSendSuccess = db.sendOTP("resourceboxbd@gmail.com", Email, "Subjected to OTP", msg);
            if (otpSendSuccess)
            { ViewBag.Message = "otp sent successfully"; }
            else { ViewBag.Message = "otp not sent"; }
            return View();
        }
        [HttpPost]

        public ActionResult OTPVerification(String email,String otp)
        {
          
            SecurityDAO db = new SecurityDAO();
            if (db.matchOTP(email, otp))
            {
                db.updateOTP(email, otp, "True");
                return RedirectToAction("EmailVerified", "Authentication", new { isVerifed = true,email });
            }
            else return RedirectToAction("EmailVerified", "Authentication", new { isVerifed = false, email });


            return View();
        }
        public ActionResult EmailVerified(bool isVerifed, String email)
        {
            ViewBag.Email = email;
            ViewBag.Verification = isVerifed;
            return View();
        }
    }

        
}
