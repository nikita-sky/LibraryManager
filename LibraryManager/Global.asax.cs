using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LibraryManager.ActionHandlers.Common;
using LibraryManager.Data.EF;
using LibraryManager.Shared;
using LibraryManager.Shared.Helpers;
using LibraryManager.Shared.IoC;

namespace LibraryManager
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new LightInjectContainer();

            container.RegisterAssemblyPerRequest(typeof(ActionHandler<>).Assembly);
            container.RegisterPerRequest<Bootsrapper>();

            container.GetAllInstances<IBootsrapper>().ForEach(b => b.Execute(container));

            container.RegisterControllers();
            container.EnableMvc();
        }
    }
}
