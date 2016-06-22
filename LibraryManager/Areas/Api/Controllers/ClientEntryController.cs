using System.Web.Mvc;
using LibraryManager.ActionHandlers;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.ControllerResults;

namespace LibraryManager.Areas.Api.Controllers
{
    public class ClientEntryController: ApiController
    {
        private readonly ClientEntryActionHandler _actionHandler;

        public ClientEntryController(ClientEntryActionHandler actionHandler)
        {
            _actionHandler = actionHandler;
        }

        [HttpGet]
        [ActionName(ACTION_INDEX)]
        public ActionResult Get(int page = 1)
            => _actionHandler.Get(page).ToJsonResult();

        [HttpPut]
        [ActionName(ACTION_INDEX)]
        public ActionResult Create(CreateClientEntryForm form)
            => _actionHandler.Create(form).ToJsonResult();

        [HttpPost]
        [ActionName(ACTION_INDEX)]
        public ActionResult Update(UpdateClientEntryForm form)
            => _actionHandler.Update(form).ToHttpResult();

        [HttpDelete]
        [ActionName(ACTION_INDEX)]
        public ActionResult Delete(int id)
            => _actionHandler.Delete(id).ToJsonResult();

        [HttpGet]
        public ActionResult Find(FindClientEntryForm form)
            => _actionHandler.Find(form).ToJsonResult();
    }
}