using System.Web.Mvc;
using LibraryManager.ActionHandlers;
using LibraryManager.ControllerResults;

namespace LibraryManager.Areas.Api.Controllers
{
    public class BookController
    {
        private readonly BooksActionHandler _actionHandler;
        public BookController(BooksActionHandler actionHandler)
        {
            _actionHandler = actionHandler;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var result = _actionHandler.Get(page);
            return new JsonCamelCaseResult(result);
        }
    }
}