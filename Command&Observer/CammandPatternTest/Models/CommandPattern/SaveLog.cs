using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CammandPatternTest.Models.CommandPattern
{
    public class SaveLog:Icommand
    {

        private LoginManager manager;

        public SaveLog(LoginManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.SavetheLog();
        }
    }
}