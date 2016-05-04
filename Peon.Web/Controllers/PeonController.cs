using Peon.Game;
using Peon.Maps;
using Peon.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peon.Web.Controllers
{
    public class PeonController : JollyGood.MVC.ControllerWithJson
    {
        PeonDbContext db = new PeonDbContext();

        // GET: Peon
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Map()
        {
            return View();
        }

        class DriverList : IDriverList
        {
            public DriverList(System.Data.Entity.DbSet<Peon.Game.Driver> dbSet)
            {
                this.dbSet = dbSet;
            }
            System.Data.Entity.DbSet<Peon.Game.Driver> dbSet;

            public void Add(Driver driver) { dbSet.Add(driver); }
        }

        static object DriverLock = new object();
        public JsonResult MapAjax()
        {
            lock(DriverLock)
            {
                DateTime now = DateTime.Now;
                bool changed = false;

                DriverList drivers = new DriverList(db.Drivers);
                foreach (BaseStation station in db.BaseStations.ToList())
                {
                    changed = station.Update(now, drivers) || changed;
                }

                foreach (Driver driver in db.Drivers.ToList())
                {
                    changed = driver.Update(now) || changed;

                    if (driver.Route.Count == 0)
                    {
                        db.Drivers.Remove(driver);
                        changed = true;
                    }
                }

                if (changed)
                    db.SaveChanges();

                var response = new { baseStations = db.BaseStations.ToList(), drivers = db.Drivers.ToList() };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
    }
}