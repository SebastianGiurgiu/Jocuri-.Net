using Schelet_Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schelet_Server.Service;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;

namespace Schelet_Server
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 55555;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);


            IDictionary<string, string> propss = new SortedList<string, String>();
            Repository<User> repouser = new Repository<User>();
            Repository<Jucator> repojucator=new Repository<Jucator>();
            Repository<Joc> repojoc=new Repository<Joc>();
            Repository<JocJucator> repojocjucator=new Repository<JocJucator>();

            //RepoClient repoclient = new RepoClient(propss);
            //RepoExcursii repoExcursii = new RepoExcursii(propss);
            //RepoRezervari repoRezervari = new RepoRezervari(propss);
            //RepoUseri repoUseri = new RepoUseri(propss);
            //RepoUseri2 repoUseri2 = new RepoUseri2();

            ///   Service service = new Service(repoclient, repoExcursii, repoRezervari, repoUseri, repoUseri2);


            var server = new MyServer(repouser,repojucator,repojoc,repojocjucator);


            RemotingServices.Marshal(server, "Chat");


            // the server will keep running until keypress.
            Console.WriteLine("Server started ...");
            Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();




        }
    }
}
