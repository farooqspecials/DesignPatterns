using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CammandPatternTest.Models.ObserverPattern
{
    public class ActivityNotifier : IContactObserver
    {
        private CommandDatabaseEntities db = new CommandDatabaseEntities();
        public void Update(tbl_Contact contact)
        {
           
                tbl_Activity notification = new tbl_Activity();
                notification.Description = $"New forum post - {contact} - received on {DateTime.Now}";
                notification.Time = DateTime.Now;
                db.tbl_Activity.Add(notification);
                db.SaveChanges();
           
        }
    }
}