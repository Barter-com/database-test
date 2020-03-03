using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using database_test.Models;

namespace database_test.Controllers
{
    public class trader_indexController : Controller
    {
        private MYFIRSTEntities db = new MYFIRSTEntities();

        // GET: trader_index
        public ActionResult Index()
        {
            return View(db.trader_indices.ToList());
        }

        // GET: trader_index/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trader_index trader_index = db.trader_indices.Find(id);
            if (trader_index == null)
            {
                return HttpNotFound();
            }
            return View(trader_index);
        }

        // GET: trader_index/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: trader_index/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "traderID,firstname,lastname,email")] trader_index trader_index)
        {
            if (ModelState.IsValid)
            {
                db.trader_indices.Add(trader_index);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trader_index);
        }

        // GET: trader_index/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trader_index trader_index = db.trader_indices.Find(id);
            if (trader_index == null)
            {
                return HttpNotFound();
            }
            return View(trader_index);
        }

        // POST: trader_index/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "traderID,firstname,lastname,email")] trader_index trader_index)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trader_index).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trader_index);
        }

        // GET: trader_index/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trader_index trader_index = db.trader_indices.Find(id);
            if (trader_index == null)
            {
                return HttpNotFound();
            }
            return View(trader_index);
        }

        // POST: trader_index/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trader_index trader_index = db.trader_indices.Find(id);
            db.trader_indices.Remove(trader_index);
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
