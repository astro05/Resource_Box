using System.Web.Mvc;

namespace ResourceBox.Areas.Features
{
    public class FeaturesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Features";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Features_default",
                "Features/{controller}/{action}/{id}",
                new { controller = "Features", action = "Features", id = UrlParameter.Optional }
            );
        }
    }
}