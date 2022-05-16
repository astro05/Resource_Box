using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ResourceBox.Areas.FAQ
{
    public class FAQAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FAQ";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FAQ_default",
                "FAQ/{controller}/{action}/{id}",
                new { controller = "FAQ", action = "FAQ", id = UrlParameter.Optional }
            );
        }
    }
}