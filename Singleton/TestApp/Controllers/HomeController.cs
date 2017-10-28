using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebsiteMetadata metadata = WebsiteMetadata.GetInstance();
            try
            {
               
           
                throw new Exception("Form 1 did something bad");

               
            }
            catch (Exception ex)
            {
                Stopwatch sw = Stopwatch.StartNew();
                

                ExceptionHandler.Instance.WriteExceptionLog(ex);
                sw.Stop();

                Console.WriteLine(sw.Elapsed.Milliseconds);
            }
            return View("Index", metadata);
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}