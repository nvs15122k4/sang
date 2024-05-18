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
    public class KhoisController : Controller
    {
        private sangEntities db = new sangEntities();

        // GET: Khois
        public ActionResult Index()
        {
            return View(db.Khoi.ToList());
        }

        // GET: Khois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoi khoi = db.Khoi.Find(id);
            if (khoi == null)
            {
                return HttpNotFound();
            }
            return View(khoi);
        }

        // GET: Khois/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoi,TenKhoi")] Khoi khoi)
        {
            if (ModelState.IsValid)
            {
                db.Khoi.Add(khoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoi);
        }

        // GET: Khois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoi khoi = db.Khoi.Find(id);
            if (khoi == null)
            {
                return HttpNotFound();
            }
            return View(khoi);
        }

        // POST: Khois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoi,TenKhoi")] Khoi khoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoi);
        }

        // GET: Khois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoi khoi = db.Khoi.Find(id);
            if (khoi == null)
            {
                return HttpNotFound();
            }
            return View(khoi);
        }

        // POST: Khois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Khoi khoi = db.Khoi.Find(id);
            db.Khoi.Remove(khoi);
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
