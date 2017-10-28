using CammandPatternTest.Models;
using CammandPatternTest.Models.ObserverPattern;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CammandPatternTest.Controllers
{
    public class ObserverController : Controller
    {
        private CommandDatabaseEntities db = new CommandDatabaseEntities();
        // GET: Observer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tbl_Contact post)
        {
            

            if (ModelState.IsValid)
            {
                Stopwatch sw = Stopwatch.StartNew();
                ContactNotifier observer1 = new ContactNotifier();

                ActivityNotifier observer2 = new ActivityNotifier();

                post.date = DateTime.Now;


                db.tbl_Contact.Add(post);
                db.SaveChanges();









                TempData["SM"] = "You have added a new Record!";
                MainNotifier notifier = new MainNotifier();

                //ForumNotifier notifier = new ForumNotifier();


                notifier.Subscribe(observer1);

                notifier.Subscribe(observer2);

                notifier.Notify(post);

                sw.Stop();
                ViewBag.ExecutionTime = sw.Elapsed.Milliseconds;
                return View("Index", post);

            } else
            {
                return View("Index");
            }

           
        }

    }

        

}
