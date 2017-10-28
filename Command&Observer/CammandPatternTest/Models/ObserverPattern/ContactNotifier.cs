using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CammandPatternTest.Models.ObserverPattern
{
    public class ContactNotifier : IContactObserver
    {
        private CommandDatabaseEntities db = new CommandDatabaseEntities();
        //send email to all admins about New Contact Message
        public void Update(tbl_Contact contact)
        {
            
            var email = db.Login_table.Where(x => x.Role == "A").Select(x => x.EmailAddress);
            var fromAddress = new MailAddress("farooqspecials@gmail.com", "Farooq Abdullah");

            MailAddressCollection TO_addressList = new MailAddressCollection();
            //3.Prepare the Destination email Addresses list
            foreach (var curr_address in email)
            {
                MailAddress mytoAddress = new MailAddress(curr_address, curr_address);
                TO_addressList.Add(mytoAddress);
            }

           
            const string fromPassword = "******";
            const string subject = "Notification";
           string body = "Hello" + TO_addressList + " Contact is From  User : " + contact.username + " Description is  " + contact.Details + "";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            //6.Complete the message and SEND the email:
            using (var message = new MailMessage()
            {
                From = fromAddress,
                Subject = subject,
                Body = body,
            })
            {
                message.To.Add(TO_addressList.ToString());
                smtp.Send(message);
            }



        }
    }
}