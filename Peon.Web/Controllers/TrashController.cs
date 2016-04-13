using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peon.Web.Controllers
{
    public class TrashController : Controller
    {
        // GET: Trash
        public ActionResult Index()
        {
            return View();
        }

        public string Test()
        {
            return "TEST";
        }

        public ActionResult Conc(string a, int id=1)
        {
            //            return string.Format("A: {0}<br/>ID: {1}<hr/>", a, id);

            ViewBag.A = a;
            ViewBag.ID = id;

            return View();
        }
    }
}