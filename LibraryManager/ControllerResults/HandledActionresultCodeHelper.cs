using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using LibraryManager.ActionHandlers.Common;

namespace LibraryManager.ControllerResults
{
    public static class HandledActionResultCodeHelper
    {
        private static readonly IDictionary<HandledActionResultCode, HttpStatusCode> _resultToHttpCode = new Dictionary
            <HandledActionResultCode, HttpStatusCode>
        {
            {HandledActionResultCode.BadRequest, HttpStatusCode.BadRequest},
            {HandledActionResultCode.Failure, HttpStatusCode.InternalServerError},
            {HandledActionResultCode.Forbidden, HttpStatusCode.Forbidden},
            {HandledActionResultCode.NotFound, HttpStatusCode.NotFound},
            {HandledActionResultCode.Success, HttpStatusCode.OK}
        };

        public static HttpStatusCode ToHttpStatusCode(this HandledActionResultCode code)
            => _resultToHttpCode[code];

        public static HttpStatusCodeResult ToHttpResult(this HandledActionResult actionResult)
            => new HttpStatusCodeResult(actionResult.Code.ToHttpStatusCode());
    }
}