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
    public class tablerestsController : Controller
    {
        private ExamenEntities1 db = new ExamenEntities1();

        // GET: tablerests
        public ActionResult Index()
        {
            return View(db.tablerests.ToList());
        }

        // GET: tablerests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablerest tablerest = db.tablerests.Find(id);
            if (tablerest == null)
            {
                return HttpNotFound();
            }
            return View(tablerest);
        }

        // GET: tablerests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tablerests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_participant1,id_participant2,poztitie_barcuta1,poztie_barcuta2,numar_incercari_jucator1,numar_incercari_jucator2,castigator_joc")] tablerest tablerest)
        {
            if (ModelState.IsValid)
            {
                db.tablerests.Add(tablerest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablerest);
        }

        // GET: tablerests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablerest tablerest = db.tablerests.Find(id);
            if (tablerest == null)
            {
                return HttpNotFound();
            }
            return View(tablerest);
        }

        // POST: tablerests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_participant1,id_participant2,poztitie_barcuta1,poztie_barcuta2,numar_incercari_jucator1,numar_incercari_jucator2,castigator_joc")] tablerest tablerest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablerest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablerest);
        }

        // GET: tablerests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablerest tablerest = db.tablerests.Find(id);
            if (tablerest == null)
            {
                return HttpNotFound();
            }
            return View(tablerest);
        }

        // POST: tablerests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tablerest tablerest = db.tablerests.Find(id);
            db.tablerests.Remove(tablerest);
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
