using System.Linq;
using System.Net;
using System.Web.Mvc;
using LibraryManager.ControllerResults;

namespace LibraryManager.Filters
{
    public class ValidateModelStateAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.Controller.ViewData.ModelState;
            if (modelState.IsValid)
                return;

            context.Result = new JsonCamelCaseResult(modelState.Keys.ToArray())
            {
                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }
}