using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using stretegypattern.Models;
using System.Diagnostics;

namespace stretegypattern.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Products
        public ActionResult Index()
        {
            Customers customer = new Customers();

            return View(db.Products.ToList());
        }

        public decimal GetDis(int discount, int productId)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Customers customer = new Customers();
            var products = db.Products.ToList();

            decimal price = db.Products.Where(x => x.Id == productId).FirstOrDefault().ProductPrice;

            switch (discount)
            {

                case 1:
                    customer.SetDiscountStrategy(new LoyalStudentDiscount());
                    price = customer.ApplyDiscount(price);
                    break;
                default:
                    customer.SetDiscountStrategy(new LoyaltyDiscount());
                    price = customer.ApplyDiscount(price);
                    break;
            }

            //return customer.ApplyDiscount(price);
            sw.Stop();
            ViewBag.ExecutionTime = sw.Elapsed.Milliseconds;
            return price;
            

        }

        public ActionResult helloPrice(int productid,decimal Productprice)
        {

            String a = "produt ID id " + productid + "and priec" + Productprice;
            //The viewbag Approach is right
            //ViewBag.MyString = "produt ID id " + productid +"yes"+Productprice+"yes";
            //This approach is also correct
            // return View("helloPrice", (object)a);
            return View((object)a);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,ProductPrice")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,ProductPrice")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
