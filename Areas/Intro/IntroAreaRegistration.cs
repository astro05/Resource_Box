using System.Web.Mvc;

namespace ResourceBox.Areas.Intro
{
    public class IntroAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Intro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Intro_default",
                "Intro/{controller}/{action}/{id}",
                new {   controller = "Intro", action = "Intro_loading", id = UrlParameter.Optional }
            );
        }
    }
}