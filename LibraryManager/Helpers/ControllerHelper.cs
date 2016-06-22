using System.Net;
using System.Web.Mvc;
using LibraryManager.ControllerResults;

namespace LibraryManager.Helpers
{
    public static class ControllerHelper
    {
        public static ActionResult Json(this Controller controller, object data, HttpStatusCode code = HttpStatusCode.OK)
            => new JsonCamelCaseResult(data)
            {
                StatusCode = code
            };
    }
}