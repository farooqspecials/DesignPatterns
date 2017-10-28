using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CammandPatternTest.Models.CommandPattern
{
    public class Invoker
    {
        public List<Icommand> Commands { get; set; } = new List<Icommand>();

        public void Execute()
        {

            foreach (Icommand command in Commands)
            {
                command.Execute();
            }
           

        }
    }
}