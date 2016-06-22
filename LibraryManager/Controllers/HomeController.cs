using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return Content("Hello world");
        }
    }
}