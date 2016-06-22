using System.Web.Mvc;
using LibraryManager.ActionHandlers.Common;
using LibraryManager.ControllerResults;
using LibraryManager.Filters;

namespace LibraryManager.Areas.Api.Controllers
{
    [ValidateModelState]
    public abstract class ApiController: Controller
    {
        public const string ACTION_INDEX = "Index";

        protected new ActionResult Json(object data)
            => new JsonCamelCaseResult(data);

        protected ActionResult Json<T>(QueryResult<T> queryResult)
        {
            var jsonObject = JsonQueryResult<T>.FromQueryResult(queryResult);
            return Json(jsonObject);
        }

        protected ActionResult Json(HandledActionResult statusCode)
        {
            return new JsonCamelCaseResult(statusCode);
        }
    }
}