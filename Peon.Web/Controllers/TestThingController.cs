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
    public class TestThingController : Controller
    {
        private ThingDbContext db = new ThingDbContext();

        // GET: TestThings
        public ActionResult Index(string search, string group)
        {
            var groupQuery = from t in db.Things select t.Group;
            ViewBag.group = new SelectList(groupQuery.Distinct().ToList());

            var things = from t in db.Things select t;

            if (!string.IsNullOrEmpty(search))
            {
                things = things.Where(t => t.Name.Contains(search));
            }

            if (!string.IsNullOrEmpty(group))
            {
                things = things.Where(t => t.Group == group);
            }
            return View(things);
        }

        // GET: TestThings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestThing testThing = db.Things.Find(id);
            if (testThing == null)
            {
                return HttpNotFound();
            }
            if(testThing is DerivedThing)
            {
                return RedirectToAction("Details", "DerivedThing", new { id = id });
            }
            return View(testThing);
        }

        // GET: TestThings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestThings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Group,Value,Additional,Sub")] TestThing testThing)
        {
            if (ModelState.IsValid)
            {
                db.Things.Add(testThing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testThing);
        }

        // GET: TestThings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestThing testThing = db.Things.Find(id);
            if (testThing == null)
            {
                return HttpNotFound();
            }
            if (testThing is DerivedThing)
            {
                return RedirectToAction("Edit", "DerivedThing", new { id = id });
            }
            return View(testThing);
        }

        // POST: TestThings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Group,Value,Additional,Sub")] TestThing testThing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testThing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testThing);
        }

        // GET: TestThings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestThing testThing = db.Things.Find(id);
            if (testThing == null)
            {
                return HttpNotFound();
            }
            return View(testThing);
        }

        // POST: TestThings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestThing testThing = db.Things.Find(id);
            db.Things.Remove(testThing);
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
