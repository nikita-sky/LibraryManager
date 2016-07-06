using System.Web.Mvc;

namespace LibraryManager.Areas.Api
{
    public class ApiAreaRegistration: AreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;

            context.MapRoute("ApiDelete", "Api/{controller}/{id}", new { action = "Index" }, new { id = "\\d+" });

            context.MapRoute(
                "ApiDefault",
                "Api/{controller}/{action}/{id}",
                new { action="Index", id = UrlParameter.Optional}
            );
        }

        public override string AreaName => "Api";
    }
}