using System.Web.Mvc;

namespace ResourceBox.Areas.ContactUs
{
    public class ContactUsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ContactUs";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ContactUs_default",
                "ContactUs/{controller}/{action}/{id}",
                new { Controller = "ContactUs", action = "ContactUs", id = UrlParameter.Optional }
            );
        }
    }
}