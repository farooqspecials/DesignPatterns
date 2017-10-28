using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CammandPatternTest.Models.ObserverPattern
{
    public class MainNotifier : IContactNotifier
    {
        private static List<IContactObserver> observers;

        static MainNotifier()
        {
            observers = new List<IContactObserver>();

        }
        public void Notify(tbl_Contact post)
        {
            foreach (IContactObserver observer in observers)

            {
                observer.Update(post);
            }
        }

        public void Subscribe(IContactObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IContactObserver observer)
        {
            observers.Remove(observer);
        }
    }

}
