using System.Web.Mvc;
using LibraryManager.ActionHandlers;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.ControllerResults;

namespace LibraryManager.Areas.Api.Controllers
{
    
    public class BookController: ApiController
    {
        private readonly BooksActionHandler _actionHandler;

        public BookController(BooksActionHandler actionHandler)
        {
            _actionHandler = actionHandler;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
            => _actionHandler.Get(page).ToJsonResult();

        [HttpPut]
        [ActionName(ACTION_INDEX)]
        public ActionResult Create(CreateBookForm form)
            => _actionHandler.Create(form).ToJsonResult();

        [HttpPost]
        [ActionName(ACTION_INDEX)]
        public ActionResult Update(UpdateBookForm form)
            => _actionHandler.Update(form).ToHttpResult();

        [HttpDelete]
        [ActionName(ACTION_INDEX)]
        public ActionResult Delete(int id)
            => _actionHandler.Delete(id).ToJsonResult();

        [HttpGet]
        public ActionResult Find(string title, int page)
            => _actionHandler.Find(title, page).ToJsonResult();
    }
}