using System.Web.Mvc;

namespace ResourceBox.Areas.UserRecord
{
    public class UserRecordAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserRecord";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserRecord_default",
                "UserRecord/{controller}/{action}/{id}",
                new { Controller = "UserRecord",action = "UserRecord", id = UrlParameter.Optional }
            );
        }
    }
}