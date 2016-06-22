using System;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LibraryManager.ControllerResults
{
    public class JsonCamelCaseResult: ActionResult
    {
        public object Data { get; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public JsonCamelCaseResult(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public JsonCamelCaseResult(object data)
        {
            Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var response = context.HttpContext.Response;
            response.ContentEncoding = Encoding.UTF8;
            response.ContentType = "application/json";
            response.StatusCode = (int)StatusCode;

            if (Data == null)
                return;

            response.Write(JsonConvert.SerializeObject(Data, JsonSerializerSettings));
        }
    }
}