using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CammandPatternTest.Models;

namespace CammandPatternTest.Controllers
{
    [Authorize(Roles = "A")]
    public class Login_tableController : Controller
    {
        private CommandDatabaseEntities db = new CommandDatabaseEntities();

        // GET: Login_table
        public ActionResult Index()
        {
            return View(db.Login_table.ToList());
        }

        // GET: Login_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_table login_table = db.Login_table.Find(id);
            if (login_table == null)
            {
                return HttpNotFound();
            }
            return View(login_table);
        }

        // GET: Login_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login_table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,Password")] Login_table login_table)
        {
            if (ModelState.IsValid)
            {
                db.Login_table.Add(login_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login_table);
        }

        // GET: Login_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_table login_table = db.Login_table.Find(id);
            if (login_table == null)
            {
                return HttpNotFound();
            }
            return View(login_table);
        }

        // POST: Login_table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,Password")] Login_table login_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login_table);
        }

        // GET: Login_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_table login_table = db.Login_table.Find(id);
            if (login_table == null)
            {
                return HttpNotFound();
            }
            return View(login_table);
        }

        // POST: Login_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login_table login_table = db.Login_table.Find(id);
            db.Login_table.Remove(login_table);
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
