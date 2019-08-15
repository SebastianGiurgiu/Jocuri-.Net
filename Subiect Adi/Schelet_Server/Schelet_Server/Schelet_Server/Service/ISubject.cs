using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schelet_Server.Service
{
    public interface ISubject
    {

        void AddObserver(IObserver observer);
        void NotifyObservers();
        void RemoveObserver(IObserver observer);


    }
}
