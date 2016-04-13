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
    public class ChildThingController : Controller
    {
        private ThingDbContext db = new ThingDbContext();

        // GET: ChildThing
        public ActionResult Index()
        {
            var childThings = db.ChildThings.Include(c => c.Thing);
            return View(childThings.ToList());
        }

        // GET: ChildThing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildThing childThing = db.ChildThings.Find(id);
            childThing.Thing = db.Things.Find(childThing.ThingID);
            if (childThing == null)
            {
                return HttpNotFound();
            }
            return View(childThing);
        }

        // GET: ChildThing/Create
        public ActionResult Create()
        {
            ViewBag.ThingID = new SelectList(db.Things, "ID", "Name");
            return View();
        }

        // POST: ChildThing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,C,ThingID")] ChildThing childThing)
        {
            if (ModelState.IsValid)
            {
                db.ChildThings.Add(childThing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThingID = new SelectList(db.Things, "ID", "Name", childThing.ThingID);
            return View(childThing);
        }

        // GET: ChildThing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildThing childThing = db.ChildThings.Find(id);
            if (childThing == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThingID = new SelectList(db.Things, "ID", "Name", childThing.ThingID);
            return View(childThing);
        }

        // POST: ChildThing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,C,ThingID")] ChildThing childThing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childThing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThingID = new SelectList(db.Things, "ID", "Name", childThing.ThingID);
            return View(childThing);
        }

        // GET: ChildThing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildThing childThing = db.ChildThings.Find(id);
            if (childThing == null)
            {
                return HttpNotFound();
            }
            return View(childThing);
        }

        // POST: ChildThing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChildThing childThing = db.ChildThings.Find(id);
            db.ChildThings.Remove(childThing);
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
