using LibraryManager.ActionHandlers.Common;

namespace LibraryManager.ControllerResults
{
    public static class QueryResultHelper
    {
        public static JsonCamelCaseResult ToJsonResult<T>(this QueryResult<T> queryResult)
        {
            return queryResult.Code == HandledActionResultCode.Success
                ? new JsonCamelCaseResult(JsonQueryResult<T>.FromQueryResult(queryResult))
                : new JsonCamelCaseResult(queryResult.Code.ToHttpStatusCode());
        }
    }
}