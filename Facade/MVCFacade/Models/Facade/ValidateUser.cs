using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFacade.Models.Facade
{
    public class ValidateUser
    {
        private facadetestEntities db = new facadetestEntities();
        public bool EmailExist(UserInfo data)
        {


            string userEmailValue = data.Email.ToString();
            int count = db.UserInfoes.Where(x => x.Email == userEmailValue).ToList().Count();
            if (count != 0)
                return false;
            else
                return true;

        }
    }
}