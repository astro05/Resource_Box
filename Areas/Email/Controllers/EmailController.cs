using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResourceBox.Models;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ResourceBox.Areas.Email.Controllers
{
    [RouteArea("Email")]

    public class EmailController : Controller
    {
        // GET: Email/Email
        public ActionResult Email()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Email(string To, string Subject, string message)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    var senderemail = new MailAddress("resourceboxbd@gmail.com", "ResourceBox");
                    var receiveremail = new MailAddress(To, "ResourceBox");
                    var password = "resourcebox3719";
                    var sub = Subject;
                    var body = message;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, password)

                    };

                    using (var mess = new MailMessage(senderemail, receiveremail)
                    {
                        Subject = Subject,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);
                    }

                    return View();


                }

            }
            catch (Exception)
            {
                ViewBag.Error = "There is something wrong";
            }


            return View();
        }



    }


}
