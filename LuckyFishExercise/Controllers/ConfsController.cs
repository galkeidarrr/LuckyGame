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
    public class ConfsController : Controller
    {
        private gameDBContext db = new gameDBContext();

        // GET: Confs
        public ActionResult Index()
        {
            return View(db._Configuration.ToList());
        }

        // GET: Confs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conf conf = db._Configuration.Find(id);
            if (conf == null)
            {
                return HttpNotFound();
            }
            return View(conf);
        }

        // GET: Confs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Confs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "_confID,_bet,_numScratchcards,_numSignOnWheel,_numSignOnScratchcards,_repeat,_numSelectedSigns,_withJoker")] Conf conf)
        {
            if (ModelState.IsValid)
            {
                db._Configuration.Add(conf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conf);
        }

        // GET: Confs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conf conf = db._Configuration.Find(id);
            if (conf == null)
            {
                return HttpNotFound();
            }
            return View(conf);
        }

        // POST: Confs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "_confID,_bet,_numScratchcards,_numSignOnWheel,_numSignOnScratchcards,_repeat,_numSelectedSigns,_withJoker")] Conf conf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conf);
        }

        // GET: Confs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conf conf = db._Configuration.Find(id);
            if (conf == null)
            {
                return HttpNotFound();
            }
            return View(conf);
        }

        // POST: Confs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conf conf = db._Configuration.Find(id);
            db._Configuration.Remove(conf);
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
