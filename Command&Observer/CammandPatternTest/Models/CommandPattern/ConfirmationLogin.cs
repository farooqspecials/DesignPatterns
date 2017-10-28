using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CammandPatternTest.Models.CommandPattern
{
    public class ConfirmationLogin:Icommand
    {
        private LoginManager manager;

        public ConfirmationLogin(LoginManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.SendEmail();
        }

    }
}