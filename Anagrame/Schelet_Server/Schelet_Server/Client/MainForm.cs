using Schelet_Server;
using Schelet_Server.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form,IObserver
    {

        //   ClientCtr ctr;
        MyServer server;
        LogForm logForm;
        public Jucator Jucator;
        public List<int> iduri;
        public int idJoc;

        public MainForm()
        {
            InitializeComponent();
            iduri = new List<int>();
        }

        public void update()
        {
            // Console.WriteLine("Se schimba chestii si pe altundeva");

            //if (!server.SfarsitJoc(idJoc))
            //{
            //    if (server.TreciLaUrmatorulCuvant(idJoc)){

            //        cuvantprimit.Text = server.GenerareCuvant().ToString();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Asteapta sa aleaga toti");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Joc incheiat");
            //}

            LoadProbaDTO("dadsa");
        }
        public void LoadProbaDTO(Object list)
        {
          cuvantprimit.BeginInvoke(new UpdateGridViewCallback(this.UpdateGridView), new object[] { cuvantprimit, (String)list });
        }

        public delegate void UpdateGridViewCallback(Label dataGridView, String list);



        private void UpdateGridView(Label dataGridView, String list)
        {
            if (!server.SfarsitJoc(idJoc))
            {
                if (server.TreciLaUrmatorulCuvant(idJoc))
                {

                    cuvantprimit.Text = server.GenerareCuvant().ToString();
                }
               // else
              //  {
               //     MessageBox.Show("Asteapta sa aleaga toti");
               // }

            }
            else
            {
                MessageBox.Show("Joc incheiat");
            }

        }
       


        public void setCtr(MyServer server,LogForm logForm)
        {
            this.server = server;
            this.logForm = logForm;
        }

        public void SetJucator(Jucator jucator)
        {
            this.Jucator = jucator;
            IdJucatorLabel.Text = Jucator.id.ToString();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            // mai daca e cazul ceva iesire din joc
            logForm.Show();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            idJoc=server.creareJoc();
            server.startJoc(); 

            List<IObserver> observers = server.getJucatori();
          
            foreach(var ob in observers)
            {
                MainForm fictiv = (MainForm)ob;
                fictiv.idJoc = idJoc;
                int id = fictiv.Jucator.id;
                iduri.Add(id);
            }

            

            server.creareJucatorJoc(iduri, idJoc);

            server.NotifyObservers();

           // server.TreciLaUrmatorulCuvant(idJoc);

          //  cuvantprimit.Text = server.GenerareCuvant().ToString();

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            server.selectareCuvantJucator(Jucator.id, idJoc, textBox1.Text);
            server.NotifyObservers();

        }
    }
}
