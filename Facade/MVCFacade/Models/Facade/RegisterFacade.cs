using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFacade.Models.Facade
{
    public class RegisterFacade
    {

        public string UserRegistration(UserInfo data)
        {
            ValidateUser validate = new ValidateUser();
            RegisterData register = new RegisterData();
            SendEmails send = new SendEmails();
            bool email;
            bool ret;
            string message;

            email = validate.EmailExist(data);
            if (email == true)
            {
               ret= register.RegisterAccount(data);
               send.SendConfirmationEmail(data);
                return message = "Email is Registered Successfully";
                //return RedirectToAction("Index");
            }
            else
            {

                return message = "Email Already Exists in the System";
            } 
           
            
           
          
            

            

        }
       
    }
}