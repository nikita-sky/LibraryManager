using System.Web.Mvc;
using LibraryManager.ActionHandlers;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.ControllerResults;

namespace LibraryManager.Areas.Api.Controllers
{
    public class LibraryCardController: ApiController
    {
        private readonly LibraryCardActionHandler _actionHandler;

        public LibraryCardController(LibraryCardActionHandler actionHandler)
        {
            _actionHandler = actionHandler;
        }

        [HttpGet]
        [ActionName(ACTION_INDEX)]
        public ActionResult Get(int page = 1)
            => _actionHandler.Get(page).ToJsonResult();

        [HttpPut]
        [ActionName(ACTION_INDEX)]
        public ActionResult Create(CreateLibraryCardForm form)
            => _actionHandler.Create(form).ToJsonResult();

        [HttpPost]
        [ActionName(ACTION_INDEX)]
        public ActionResult Update(UpdateLibraryCardForm form)
            => _actionHandler.Update(form).ToHttpResult();

        [HttpDelete]
        [ActionName(ACTION_INDEX)]
        public ActionResult Delete(int id)
            => _actionHandler.Delete(id).ToJsonResult();

        [HttpGet]
        public ActionResult Find(string fullName, int page = 1)
            => _actionHandler.Find(fullName, page).ToJsonResult();

        [HttpGet]
        public ActionResult Search(string query)
            => Json(_actionHandler.Search(query));
    }
}