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
using System.Text;

namespace ResourceBox.Areas.ContactUs.Controllers
{
    [RouteArea("ContactUs")]
    public class ContactUsController : Controller
    {
        // GET: ContactUs/ContactUs
        public ActionResult ContactUs()
        {
            return View();
        }

/*
        [HttpPost]
        public ActionResult FormSubmit()
        {
            //Validate Google recaptcha here
            var response = Request["g-recaptcha-response"];
            string secretKey = "6Ld3EH8aAAAAAEqbh6A9GpigUyq4iswtUZd1TiLH";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";

            //When you will post form for save data, you should check both the model validation and google recaptcha validation
            //EX.
            *//* if (ModelState.IsValid && status)
            {

            }*//*

            //Here I am returning to Index page for demo perpose, you can use your view here
            return View("Index");
        }
*/

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ContactUs(string name, string email, string contact_no, string subject, string message)
        {
            ViewBag.sentStatus = 2;


            StringBuilder sbComments = new StringBuilder();

            // Encode the text that is coming from comments textbox
            sbComments.Append(HttpUtility.HtmlEncode(message));

            // Only decode bold and underline tags
            sbComments.Replace("&lt;b&gt;", "<b>");
            sbComments.Replace("&lt;/b&gt;", "</b>");
            sbComments.Replace("&lt;u&gt;", "<u>");
            sbComments.Replace("&lt;/u&gt;", "</u>");
            message = sbComments.ToString();

            // HTML encode the text that is coming from name textbox
            string strEncodedName = HttpUtility.HtmlEncode(message);
            message = strEncodedName;




            //Validate Google recaptcha here
            var response = Request["g-recaptcha-response"];
            string secretKey = "6Ld3EH8aAAAAAEqbh6A9GpigUyq4iswtUZd1TiLH";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";

            //When you will post form for save data, you should check both the model validation and google recaptcha validation
            //EX.
            if (ModelState.IsValid && status)
            {
               

                try
                {
                    if (ModelState.IsValid)
                    {
                        var ownermail = "resourceboxbd@gmail.com";
                        var senderemail = new MailAddress(email, "ResourceBox");
                        var receiveremail = new MailAddress(ownermail, name);
                        var password = "resourcebox3719";
                        var sub = subject;
                        var body = "From: " + email + "\n" +
                                   "Name: " + name + "\n" +
                                   "Contact no : " + contact_no + "\n \n" +
                                    message;



                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(receiveremail.Address, password)

                        };

                        using (var mess = new MailMessage(senderemail, receiveremail)
                        {
                            Subject = subject,
                            Body = body
                        }
                        )
                        {
                            smtp.Send(mess);
                        }

                        ViewBag.Suc = "Success";
                        ViewBag.sentStatus = 1;

                        return View();


                    }

                }
                catch (Exception)
                {
                    ViewBag.Error = "There is something wrong";
                    ViewBag.sentStatus = 0;
                }

            }
            if(!status)
            {
                ViewBag.sentStatus = 0;
            }












            return View();
        }

    }
}



/*

< script type = "text/javascript" >
 alert('Your site is hacked');
</ script >

*/


// mail sent to client

/*[HttpPost]
public ActionResult ContactUs(string name, string email, string contact_no, string subject, string message)
{
    try
    {
        if (ModelState.IsValid)
        {

            var senderemail = new MailAddress("", "ResourceBox");
            var receiveremail = new MailAddress(email, name);
            var password = "";
            var sub = subject;
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
                Subject = subject,
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

    }*/