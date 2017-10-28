using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFacade.Models.Facade
{
    public class RegisterData
    {
        private facadetestEntities db = new facadetestEntities();
        public bool RegisterAccount(UserInfo data)
        {
            db.UserInfoes.Add(data);
            db.SaveChanges();
            return true;
        }
    }
}