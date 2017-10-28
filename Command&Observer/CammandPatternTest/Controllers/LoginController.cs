using CammandPatternTest.Models;
using CammandPatternTest.Models.CommandPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CammandPatternTest.Controllers
{
    public class LoginController : Controller
    {
        public string username;
        public string pwd;
        private CommandDatabaseEntities db = new CommandDatabaseEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Login_table user)
        {
            LoginManager manager = new LoginManager(user);
            Invoker invoker = new Invoker();
            Icommand command = null;
            //++++++++++++++++++++++++adding login +++++++++++++++++++++

            username = user.EmailAddress;
            pwd = user.Password;
            ProvideMemberShip p = new ProvideMemberShip();

            bool valid = p.ValidateUser(username, pwd);

            if (valid == true)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Stopwatch sw = Stopwatch.StartNew();
                command = new SaveLog(manager);
                invoker.Commands.Add(command);
                command = new ConfirmationLogin(manager);
                invoker.Commands.Add(command);

                invoker.Execute();
                sw.Stop();
                
                Console.WriteLine(sw.Elapsed.Milliseconds);

                return RedirectToAction("Index", "Login_table");

            }
            else
            {

                TempData["Msg"] = "Login Failed  ";
                return RedirectToAction("Index");

            }

          
        }
            

        

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
       

    }
}