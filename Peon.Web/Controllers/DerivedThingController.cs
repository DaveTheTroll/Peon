using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peon.Web.Models;

namespace Peon.Web.Controllers
{
    public class DerivedThingController : Controller
    {
        private ThingDbContext db = new ThingDbContext();

        // GET: DerivedThings
        public ActionResult Index()
        {
            return View(db.Things.OfType<DerivedThing>().ToList());
        }

        // GET: DerivedThings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DerivedThing derivedThing = (DerivedThing)db.Things.Find(id);
            if (derivedThing == null)
            {
                return HttpNotFound();
            }
            return View(derivedThing);
        }

        // GET: DerivedThings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DerivedThings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Created,Group,Value,Additional,Sub,DerivedProp")] DerivedThing derivedThing)
        {
            if (ModelState.IsValid)
            {
                db.Things.Add(derivedThing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(derivedThing);
        }

        // GET: DerivedThings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DerivedThing derivedThing = (DerivedThing)db.Things.Find(id);
            if (derivedThing == null)
            {
                return HttpNotFound();
            }
            return View(derivedThing);
        }

        // POST: DerivedThings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Created,Group,Value,Additional,Sub,DerivedProp")] DerivedThing derivedThing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(derivedThing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(derivedThing);
        }

        // GET: DerivedThings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DerivedThing derivedThing = (DerivedThing)db.Things.Find(id);
            if (derivedThing == null)
            {
                return HttpNotFound();
            }
            return View(derivedThing);
        }

        // POST: DerivedThings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DerivedThing derivedThing = (DerivedThing)db.Things.Find(id);
            db.Things.Remove(derivedThing);
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
