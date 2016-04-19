using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peon.Game;
using Peon.Web.Models;

namespace Peon.Web.Controllers
{
    public class BaseStationController : Controller
    {
        private PeonDbContext db = new PeonDbContext();

        // GET: BaseStation
        public ActionResult Index()
        {
            return View(db.BaseStations.ToList());
        }

        // GET: BaseStation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseStation baseStation = db.BaseStations.Find(id);
            if (baseStation == null)
            {
                return HttpNotFound();
            }
            return View(baseStation);
        }

        // GET: BaseStation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaseStation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location")] BaseStation baseStation)
        {
            if (ModelState.IsValid)
            {
                db.BaseStations.Add(baseStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseStation);
        }

        // GET: BaseStation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseStation baseStation = db.BaseStations.Find(id);
            if (baseStation == null)
            {
                return HttpNotFound();
            }
            return View(baseStation);
        }

        // POST: BaseStation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location")] BaseStation baseStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseStation);
        }

        // GET: BaseStation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseStation baseStation = db.BaseStations.Find(id);
            if (baseStation == null)
            {
                return HttpNotFound();
            }
            return View(baseStation);
        }

        // POST: BaseStation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseStation baseStation = db.BaseStations.Find(id);
            db.BaseStations.Remove(baseStation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
