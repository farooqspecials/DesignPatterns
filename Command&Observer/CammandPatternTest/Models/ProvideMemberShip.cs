using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CammandPatternTest.Models
{
    public class ProvideMemberShip
    {
        private CommandDatabaseEntities db = new CommandDatabaseEntities();
        public bool ValidateUser(string username, string password)
        {
            int count = db.Login_table.Where(x => x.EmailAddress == username && x.Password == password).Count();
            if (count != 0)
                return true;
            else
                return false;
        }
    }
}