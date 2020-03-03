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
    public class item_tableController : Controller
    {
        private MYFIRSTEntities db = new MYFIRSTEntities();

        // GET: item_table
        public ActionResult Index()
        {
            var item_tables = db.item_tables.Include(i => i.trader_index);
            return View(item_tables.ToList());
        }

        // GET: item_table/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item_table item_table = db.item_tables.Find(id);
            if (item_table == null)
            {
                return HttpNotFound();
            }
            return View(item_table);
        }

        // GET: item_table/Create
        public ActionResult Create()
        {
            ViewBag.itemownerID = new SelectList(db.trader_indices, "traderID", "firstname");
            return View();
        }

        // POST: item_table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemname,itemownerID")] item_table item_table)
        {
            if (ModelState.IsValid)
            {
                db.item_tables.Add(item_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemownerID = new SelectList(db.trader_indices, "traderID", "firstname", item_table.itemownerID);
            return View(item_table);
        }

        // GET: item_table/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item_table item_table = db.item_tables.Find(id);
            if (item_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemownerID = new SelectList(db.trader_indices, "traderID", "firstname", item_table.itemownerID);
            return View(item_table);
        }

        // POST: item_table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemname,itemownerID")] item_table item_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemownerID = new SelectList(db.trader_indices, "traderID", "firstname", item_table.itemownerID);
            return View(item_table);
        }

        // GET: item_table/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item_table item_table = db.item_tables.Find(id);
            if (item_table == null)
            {
                return HttpNotFound();
            }
            return View(item_table);
        }

        // POST: item_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            item_table item_table = db.item_tables.Find(id);
            db.item_tables.Remove(item_table);
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
