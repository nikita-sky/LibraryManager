using LightInject;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LibraryManager.ActionHandlers.Common;
using LibraryManager.Data.EF;
using LibraryManager.Data.Model;
using LibraryManager.Data.Model.Entity;
using LibraryManager.Shared;
using LibraryManager.Shared.Helpers;

namespace LibraryManager
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new ServiceContainer();
            container.RegisterControllers();
            RegisterRepositories(container);

            container.RegisterAssembly(typeof(ActionHandler<>).Assembly, () => new PerRequestLifeTime());
            container.GetAllInstances<IBootsrapper>().ForEach(b => b.Execute(container));

            container.EnableMvc();
        }

        private static void RegisterRepositories(IServiceRegistry container)
        {
            container.Register<IRepository<Book>, BookRepository>(new PerRequestLifeTime());
            container.Register<IRepository<LibraryCard>, LibraryCardRepository>(new PerRequestLifeTime());
            container.Register<IRepository<ClientEntry>, ClientEntryRepository>(new PerRequestLifeTime());
        }
    }
}
