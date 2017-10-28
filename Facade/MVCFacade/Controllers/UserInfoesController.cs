using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCFacade.Models;
using System.Net;
using System.Net.Mail;
using MVCFacade.Models.Facade;
using System.Diagnostics;

namespace MVCFacade.Controllers
{
    public class UserInfoesController : Controller
    {
        private facadetestEntities db = new facadetestEntities();

        // GET: UserInfoes
        public ActionResult Index()
        {
            return View(db.UserInfoes.ToList());
        }

        // GET: UserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserInfo userInfo)
        {
            Stopwatch sw = Stopwatch.StartNew();
           
          

            
            //bool ret;
            //bool email;
            string errorMsg;
            RegisterFacade registerUser = new RegisterFacade();
            if (ModelState.IsValid)
            {
                //validate if email exists
               /* email = EmailExist(userInfo)*/;
               errorMsg= registerUser.UserRegistration(userInfo);

                ViewBag.Message=errorMsg;
               

                //sending email

                //if (email == true)
                //{
                //    //user registration
                //    ret = RegisterAccount(userInfo);
                //    SendConfirmationEmail(userInfo);
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                //    ViewBag.Message = "Email Already Exists in the System";
                //}
                
                //db.UserInfoes.Add(userInfo);
                //db.SaveChanges();
               
            }

            sw.Stop();
            ViewBag.ExecutionTime = sw.Elapsed.Milliseconds;
           // Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
            return View(userInfo);
        }

        //public bool RegisterAccount(UserInfo data)
        //{
        //    db.UserInfoes.Add(data);
        //    db.SaveChanges();
        //    return true;
        //}


        //public void SendConfirmationEmail(UserInfo Data)
        //{
        //    string userEmailValue = Data.Email.ToString();
        //    string userName = Data.FirstName.ToString();
        //    var fromAddress = new MailAddress("farooqspecials@gmail.com", "Farooq Abdullah");
        //    var toAddress = new MailAddress(userEmailValue, userName);
        //    const string fromPassword = "fOOKI@321";
        //    const string subject = "Email regisration";
        //    string body = "Hello"+userName+" your Email : " +userEmailValue+ " is successfully registered";

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        //    };
        //    using (var message = new MailMessage(fromAddress, toAddress)
        //    {
        //        Subject = subject,
        //        Body = body
        //    })
        //    {
        //        smtp.Send(message);
        //    }

        //}

        //public bool EmailExist(UserInfo data)
        //{
         
            
        //     string userEmailValue = data.Email.ToString();
        //     int count = db.UserInfoes.Where(x => x.Email == userEmailValue).ToList().Count();
        //    if (count != 0)
        //        return false;
        //    else
        //        return true;
            
        //}

        // GET: UserInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo userInfo = db.UserInfoes.Find(id);
            db.UserInfoes.Remove(userInfo);
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
