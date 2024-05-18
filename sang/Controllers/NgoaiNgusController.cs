using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sang.Models;

namespace sang.Controllers
{
    public class NgoaiNgusController : Controller
    {
        private sangEntities db = new sangEntities();

        // GET: NgoaiNgus
        public ActionResult Index()
        {
            return View(db.NgoaiNgu.ToList());
        }

        // GET: NgoaiNgus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NgoaiNgu ngoaiNgu = db.NgoaiNgu.Find(id);
            if (ngoaiNgu == null)
            {
                return HttpNotFound();
            }
            return View(ngoaiNgu);
        }

        // GET: NgoaiNgus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NgoaiNgus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNgoaiNgu,TenNgoaiNgu")] NgoaiNgu ngoaiNgu)
        {
            if (ModelState.IsValid)
            {
                db.NgoaiNgu.Add(ngoaiNgu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ngoaiNgu);
        }

        // GET: NgoaiNgus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NgoaiNgu ngoaiNgu = db.NgoaiNgu.Find(id);
            if (ngoaiNgu == null)
            {
                return HttpNotFound();
            }
            return View(ngoaiNgu);
        }

        // POST: NgoaiNgus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNgoaiNgu,TenNgoaiNgu")] NgoaiNgu ngoaiNgu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ngoaiNgu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ngoaiNgu);
        }

        // GET: NgoaiNgus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NgoaiNgu ngoaiNgu = db.NgoaiNgu.Find(id);
            if (ngoaiNgu == null)
            {
                return HttpNotFound();
            }
            return View(ngoaiNgu);
        }

        // POST: NgoaiNgus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NgoaiNgu ngoaiNgu = db.NgoaiNgu.Find(id);
            db.NgoaiNgu.Remove(ngoaiNgu);
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
