using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace MVCFacade.Models.Facade
{
    public class SendEmails
    {
        public void SendConfirmationEmail(UserInfo Data)
        {
            string userEmailValue = Data.Email.ToString();
            string userName = Data.FirstName.ToString();
            var fromAddress = new MailAddress("farooqspecials@gmail.com", "Farooq Abdullah");
            var toAddress = new MailAddress(userEmailValue, userName);
            const string fromPassword = "*****"; //Use your own Credentials
            const string subject = "Email regisration";
            string body = "Hello" + userName + " your Email : " + userEmailValue + " is successfully registered";

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