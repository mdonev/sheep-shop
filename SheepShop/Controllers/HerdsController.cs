using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SheepShop.Context;
using SheepShop.Models;

namespace SheepShop.Controllers
{
    public class HerdsController : Controller
    {
        private HerdContext db = new HerdContext();

        // GET: Herds
        public ActionResult Index()
        {
            return View(db.herd.ToList());
        }

        // GET: Herds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herd herd = db.herd.Find(id);
            if (herd == null)
            {
                return HttpNotFound();
            }
            return View(herd);
        }

        // GET: Herds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,sex,BornDate")] Herd herd)
        {
            if (ModelState.IsValid)
            {
                db.herd.Add(herd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herd);
        }

        // GET: Herds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herd herd = db.herd.Find(id);
            if (herd == null)
            {
                return HttpNotFound();
            }
            return View(herd);
        }

        // POST: Herds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,sex,BornDate")] Herd herd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herd);
        }

        // GET: Herds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herd herd = db.herd.Find(id);
            if (herd == null)
            {
                return HttpNotFound();
            }
            return View(herd);
        }

        // POST: Herds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Herd herd = db.herd.Find(id);
            db.herd.Remove(herd);
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
