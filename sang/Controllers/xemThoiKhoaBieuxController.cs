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
    public class xemThoiKhoaBieuxController : Controller
    {
        private sangEntities db = new sangEntities();

        // GET: xemThoiKhoaBieux
        public ActionResult Index()
        {
            var thoiKhoaBieu = db.ThoiKhoaBieu.Include(t => t.GiaoVien).Include(t => t.Lop).Include(t => t.MonHoc);
            return View(thoiKhoaBieu.ToList());
        }

        // GET: xemThoiKhoaBieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThoiKhoaBieu thoiKhoaBieu = db.ThoiKhoaBieu.Find(id);
            if (thoiKhoaBieu == null)
            {
                return HttpNotFound();
            }
            return View(thoiKhoaBieu);
        }

        // GET: xemThoiKhoaBieux/Create
        public ActionResult Create()
        {
            ViewBag.MaGiaoVien = new SelectList(db.GiaoVien, "MaGiaoVien", "TenGiaoVien");
            ViewBag.MaLop = new SelectList(db.Lop, "MaLop", "TenLop");
            ViewBag.MaMonHoc = new SelectList(db.MonHoc, "MaMonHoc", "TenMonHoc");
            return View();
        }

        // POST: xemThoiKhoaBieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,Thu,SoThuTuTiet,MaGiaoVien,MaMonHoc")] ThoiKhoaBieu thoiKhoaBieu)
        {
            if (ModelState.IsValid)
            {
                db.ThoiKhoaBieu.Add(thoiKhoaBieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGiaoVien = new SelectList(db.GiaoVien, "MaGiaoVien", "TenGiaoVien", thoiKhoaBieu.MaGiaoVien);
            ViewBag.MaLop = new SelectList(db.Lop, "MaLop", "TenLop", thoiKhoaBieu.MaLop);
            ViewBag.MaMonHoc = new SelectList(db.MonHoc, "MaMonHoc", "TenMonHoc", thoiKhoaBieu.MaMonHoc);
            return View(thoiKhoaBieu);
        }

        // GET: xemThoiKhoaBieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThoiKhoaBieu thoiKhoaBieu = db.ThoiKhoaBieu.Find(id);
            if (thoiKhoaBieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGiaoVien = new SelectList(db.GiaoVien, "MaGiaoVien", "TenGiaoVien", thoiKhoaBieu.MaGiaoVien);
            ViewBag.MaLop = new SelectList(db.Lop, "MaLop", "TenLop", thoiKhoaBieu.MaLop);
            ViewBag.MaMonHoc = new SelectList(db.MonHoc, "MaMonHoc", "TenMonHoc", thoiKhoaBieu.MaMonHoc);
            return View(thoiKhoaBieu);
        }

        // POST: xemThoiKhoaBieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,Thu,SoThuTuTiet,MaGiaoVien,MaMonHoc")] ThoiKhoaBieu thoiKhoaBieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thoiKhoaBieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGiaoVien = new SelectList(db.GiaoVien, "MaGiaoVien", "TenGiaoVien", thoiKhoaBieu.MaGiaoVien);
            ViewBag.MaLop = new SelectList(db.Lop, "MaLop", "TenLop", thoiKhoaBieu.MaLop);
            ViewBag.MaMonHoc = new SelectList(db.MonHoc, "MaMonHoc", "TenMonHoc", thoiKhoaBieu.MaMonHoc);
            return View(thoiKhoaBieu);
        }

        // GET: xemThoiKhoaBieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThoiKhoaBieu thoiKhoaBieu = db.ThoiKhoaBieu.Find(id);
            if (thoiKhoaBieu == null)
            {
                return HttpNotFound();
            }
            return View(thoiKhoaBieu);
        }

        // POST: xemThoiKhoaBieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThoiKhoaBieu thoiKhoaBieu = db.ThoiKhoaBieu.Find(id);
            db.ThoiKhoaBieu.Remove(thoiKhoaBieu);
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
