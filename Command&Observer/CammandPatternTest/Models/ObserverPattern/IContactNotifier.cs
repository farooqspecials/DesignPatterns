using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CammandPatternTest.Models.ObserverPattern
{
    interface IContactNotifier
    {
        void Subscribe(IContactObserver observer);
        void Unsubscribe(IContactObserver observer);
        void Notify(tbl_Contact contactForm);
    }
}
