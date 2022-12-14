using System.Web.Mvc;

namespace ribellabutik.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               name: "AdminPanel_default",
                url:"AdminPanel/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces:new [] {"ribellabutik.Areas.AdminPanel.Controllers"}
            );
        }
    }
}