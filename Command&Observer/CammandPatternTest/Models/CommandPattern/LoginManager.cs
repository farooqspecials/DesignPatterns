using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;

namespace CammandPatternTest.Models.CommandPattern
{
    public class LoginManager
    {

        private CommandDatabaseEntities db = new CommandDatabaseEntities();
        public string username;
        public string pwd;
        public string name;
        public LoginManager(Login_table user)
        {
            
             username=user.EmailAddress ;
            pwd= user.Password ;
            name = user.FirstName;
            
        }
            
       

        public void SavetheLog()
        {
            LoginLog item = new LoginLog();

            item.UserName = username;
            item.LoginTime = DateTime.Now;
            ////item.CommandText = "IDENTITY_CARD";
            db.LoginLogs.Add(item);

            db.SaveChanges();
        }

        public void SendEmail()
        {
            
            var fromAddress = new MailAddress("farooqspecials@gmail.com", "Farooq Abdullah");
            var toAddress = new MailAddress(username, name);
            const string fromPassword = "******";//pls use your own credentials
            const string subject = "Email regisration";
            string body = "Hello" + name + " your Email : " + username + " is successfully login at "+ DateTime.Now+"";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }


        }
    }
}