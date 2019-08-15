using Schelet_Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schelet_Server
{
    public class MyServer : MarshalByRefObject, ISubject
    {
        public Service.Service service;

        public MyServer(Service.Service service)
        {
            this.service = service;
        }


        public bool login(string username,string password)
        {
            return service.findAftertUsernameAndPassword(username, password);
        }

        public IEnumerable<Participant> GetParticipants()
        {
            return service.GetParticipants();
        }

        public Juriu GetJuriuAfterUsername(string username)
        {
            return service.GetJuriuAfterUsername(username);
        }

        public void AdaugaRezultat(int idParticipant, int scor, string aspect)
        {
            service.AdaugaRezultat(idParticipant, scor, aspect);

        }

        public void JurizatComplet(int idParticipant)
        {
            service.JurizatComplet(idParticipant);
        }

        private IList<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.update();
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
