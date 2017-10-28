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
    public class LoginLogsController : Controller
    {
        private CommandDatabaseEntities db = new CommandDatabaseEntities();

        // GET: LoginLogs
        public ActionResult Index()
        {
            return View(db.LoginLogs.ToList());
        }

        // GET: LoginLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginLog loginLog = db.LoginLogs.Find(id);
            if (loginLog == null)
            {
                return HttpNotFound();
            }
            return View(loginLog);
        }

        // GET: LoginLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserName,LoginTime")] LoginLog loginLog)
        {
            if (ModelState.IsValid)
            {
                db.LoginLogs.Add(loginLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginLog);
        }

        // GET: LoginLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginLog loginLog = db.LoginLogs.Find(id);
            if (loginLog == null)
            {
                return HttpNotFound();
            }
            return View(loginLog);
        }

        // POST: LoginLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserName,LoginTime")] LoginLog loginLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginLog);
        }

        // GET: LoginLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginLog loginLog = db.LoginLogs.Find(id);
            if (loginLog == null)
            {
                return HttpNotFound();
            }
            return View(loginLog);
        }

        // POST: LoginLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginLog loginLog = db.LoginLogs.Find(id);
            db.LoginLogs.Remove(loginLog);
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
