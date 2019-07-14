using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LuckyFishExercise.Models;

namespace LuckyFishExercise.Controllers
{
    public class SignsController : Controller
    {
        private gameDBContext db = new gameDBContext();

        // GET: Signs
        public ActionResult Index()
        {
            return View(db._Signs.ToList());
        }

        // GET: Signs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sign sign = db._Signs.Find(id);
            if (sign == null)
            {
                return HttpNotFound();
            }
            return View(sign);
        }

        // GET: Signs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "_SignID,_SignName,_SignJoker")] Sign sign)
        {
            if (ModelState.IsValid)
            {
                db._Signs.Add(sign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sign);
        }

        // GET: Signs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sign sign = db._Signs.Find(id);
            if (sign == null)
            {
                return HttpNotFound();
            }
            return View(sign);
        }

        // POST: Signs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "_SignID,_SignName,_SignJoker")] Sign sign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sign);
        }

        // GET: Signs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sign sign = db._Signs.Find(id);
            if (sign == null)
            {
                return HttpNotFound();
            }
            return View(sign);
        }

        // POST: Signs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sign sign = db._Signs.Find(id);
            db._Signs.Remove(sign);
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
