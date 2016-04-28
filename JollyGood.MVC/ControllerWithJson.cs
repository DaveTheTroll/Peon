using System;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Text;

namespace JollyGood.MVC
{
    public class ControllerWithJson : Controller
    {
        protected override System.Web.Mvc.JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JollyGood.MVC.JsonResult() { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }

        protected override System.Web.Mvc.JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new JollyGood.MVC.JsonResult() { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }
    }
}
