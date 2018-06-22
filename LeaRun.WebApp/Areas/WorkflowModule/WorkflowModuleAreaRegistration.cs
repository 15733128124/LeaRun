using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.WorkflowModule
{
    public class WorkflowModuleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WorkflowModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WorkflowModule_default",
                "WorkflowModule/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
