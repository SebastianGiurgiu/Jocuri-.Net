using Schelet_Server;
using Schelet_Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientCtr
    {

        MyServer server;


        public ClientCtr(MyServer server)
        {
            this.server = server;
        }


        public bool Login(string username,string passoword)
        {
            return server.login(username, passoword);
        }

        public IEnumerable<Participant> GetParticipants()
        {
            return server.GetParticipants();
        }

        public Juriu GetJuriuAfterUsername(string username)
        {
            return server.GetJuriuAfterUsername(username);
        }

        public void AdaugaRezultat(int idParticipant, int scor, string aspect)
        {
            server.AdaugaRezultat(idParticipant, scor, aspect);
            server.JurizatComplet(idParticipant);
            server.NotifyObservers();
        }

      



    }
}
