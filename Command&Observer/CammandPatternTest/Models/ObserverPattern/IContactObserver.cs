using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CammandPatternTest.Models.ObserverPattern
{
    public interface IContactObserver
    {
        void Update(tbl_Contact contact);
    }
}
