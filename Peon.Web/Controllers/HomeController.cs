﻿using Peon.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Peon.Web.Controllers
{
    public class HomeController : JollyGood.MVC.ControllerWithJson
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult MapWithAjax()
        {
            return View();
        }

        public JsonResult MarkerAjax()
        {
            DateTime now = DateTime.Now;
            double d = (now - DateTime.Today).TotalSeconds * 2 * Math.PI / 30;
            LatLong location = new LatLong(52.591695 + 0.0001 * Math.Cos(d), -1.161152 + 0.0001 * Math.Sin(d));

            return Json(location, JsonRequestBehavior.AllowGet);
        }
    }
}