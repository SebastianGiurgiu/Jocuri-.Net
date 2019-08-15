using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiciiRest.Models;

namespace ServiciiRest.Controllers
{
    public class JocJucatorsController : Controller
    {
        private GhicesteCuvantEntities db = new GhicesteCuvantEntities();

        // GET: JocJucators
        public ActionResult Index()
        {
            return View(db.JocJucators.ToList());
        }

        // GET: JocJucators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JocJucator jocJucator = db.JocJucators.Find(id);
            if (jocJucator == null)
            {
                return HttpNotFound();
            }
            return View(jocJucator);
        }

        // GET: JocJucators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JocJucators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idjoc,idjucator,cuvant,mapare,punctaj,literealese,ales")] JocJucator jocJucator)
        {
            if (ModelState.IsValid)
            {
                db.JocJucators.Add(jocJucator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jocJucator);
        }

        // GET: JocJucators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JocJucator jocJucator = db.JocJucators.Find(id);
            if (jocJucator == null)
            {
                return HttpNotFound();
            }
            return View(jocJucator);
        }

        // POST: JocJucators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idjoc,idjucator,cuvant,mapare,punctaj,literealese,ales")] JocJucator jocJucator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jocJucator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jocJucator);
        }

        // GET: JocJucators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JocJucator jocJucator = db.JocJucators.Find(id);
            if (jocJucator == null)
            {
                return HttpNotFound();
            }
            return View(jocJucator);
        }

        // POST: JocJucators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JocJucator jocJucator = db.JocJucators.Find(id);
            db.JocJucators.Remove(jocJucator);
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
