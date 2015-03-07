using System.Web.Mvc;

namespace ArticleManagement.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            
            context.MapRoute(
                name: "Admin_default",
                url :"Admin/{controller}/{action}/{id}",
                defaults: new {  action = "index", id = UrlParameter.Optional }
            );
            
        }
    }
}
