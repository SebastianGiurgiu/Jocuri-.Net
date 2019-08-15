using Schelet_Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LogForm());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 0;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);
            //IServer server =
            //   (IServer)Activator.GetObject(typeof(IServer), "tcp://localhost:55555/Chat");

            MyServer server = (MyServer)Activator.GetObject(typeof(MyServer), "tcp://localhost:55555/Chat"); 

            
            MainForm mainForm = new MainForm();
           
            //MainForm mainForm = new MainForm(ctrl);
            LogForm logForm = new LogForm();
          
            mainForm.setCtr(server,logForm);
            logForm.set(server, mainForm);

            server.AddObserver(mainForm);

            Application.Run(logForm);


        }
    }
}
