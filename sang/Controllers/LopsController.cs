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
    public class LopsController : Controller
    {
        private sangEntities db = new sangEntities();

        // GET: Lops
        public ActionResult Index()
        {
            var lop = db.Lop.Include(l => l.Khoi).Include(l => l.NgoaiNgu);
            return View(lop.ToList());
        }

        // GET: Lops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lop.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // GET: Lops/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoi = new SelectList(db.Khoi, "MaKhoi", "TenKhoi");
            ViewBag.MaNgoaiNgu = new SelectList(db.NgoaiNgu, "MaNgoaiNgu", "TenNgoaiNgu");
            return View();
        }

        // POST: Lops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,TenLop,MaKhoi,MaNgoaiNgu,SiSo")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Lop.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoi = new SelectList(db.Khoi, "MaKhoi", "TenKhoi", lop.MaKhoi);
            ViewBag.MaNgoaiNgu = new SelectList(db.NgoaiNgu, "MaNgoaiNgu", "TenNgoaiNgu", lop.MaNgoaiNgu);
            return View(lop);
        }

        // GET: Lops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lop.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoi = new SelectList(db.Khoi, "MaKhoi", "TenKhoi", lop.MaKhoi);
            ViewBag.MaNgoaiNgu = new SelectList(db.NgoaiNgu, "MaNgoaiNgu", "TenNgoaiNgu", lop.MaNgoaiNgu);
            return View(lop);
        }

        // POST: Lops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop,MaKhoi,MaNgoaiNgu,SiSo")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoi = new SelectList(db.Khoi, "MaKhoi", "TenKhoi", lop.MaKhoi);
            ViewBag.MaNgoaiNgu = new SelectList(db.NgoaiNgu, "MaNgoaiNgu", "TenNgoaiNgu", lop.MaNgoaiNgu);
            return View(lop);
        }

        // GET: Lops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lop.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: Lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lop lop = db.Lop.Find(id);
            db.Lop.Remove(lop);
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
