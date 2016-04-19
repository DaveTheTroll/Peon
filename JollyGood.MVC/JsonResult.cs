using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace JollyGood.MVC
{
    public class JsonResult : System.Web.Mvc.JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            response.Write(JsonConvert.SerializeObject(Data));
        }
    }
}
