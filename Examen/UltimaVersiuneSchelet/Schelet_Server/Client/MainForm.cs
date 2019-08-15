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

        MyServer server;
        LogForm logForm;
        public Jucator jucator;
        public Joc Joc;

        public int IdJucatorCautat;



        public MainForm()
        {
            InitializeComponent();
            for (int i = 1; i <= 16; i++)
            {
                Button b = addButton(i, Color.Green);

                flowLayoutPanel1.Controls.Add(b);
                // b.Click += new EventHandler(this.buttonDoubleClick);


            }
        }

        public void update()
        {
            //   Console.WriteLine("Se schimba chestii si pe altundeva");

            LoadDTO("dsa");

        }

        public void setCtr(MyServer server,LogForm logForm)
        {
            this.server = server;
            this.logForm = logForm;
        }

        public void setJucator(Jucator jucator)
        {
            this.jucator = jucator;
            this.label1.Text = jucator.id.ToString();
        }


        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();

            server.RemoveObserver(this);
            server.FinalJoc();

            // mai daca e cazul ceva iesire din joc
            logForm.Show();
        }

        Button addButton(int i, Color color)
        {
            Button b = new Button();
            b.Name = i.ToString();
            b.Text = i.ToString();
            b.ForeColor = Color.White;
            b.BackColor = color;
            b.Font = new Font("Serif", 24, FontStyle.Bold);
            b.Width = 70;
            b.Height = 70;
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.Margin = new Padding(5);
            return b;
        }

        void buttonDoubleClick(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            int alegere=server.CeAlegere(this.Joc, this.jucator, btn.Name.ToString());

            if (alegere == 1)
            {
                labelpoz1.Text = btn.Name;
                server.AlegPoz1(this.Joc, this.jucator,btn.Name);
                labelpoz1.Text = btn.Text;
                server.NotifyObservers();
            }

            if (alegere == 2)
            {

              
                    server.AlegPoz2(this.Joc, this.jucator, btn.Name);
                
                    labelpoz2.Text = btn.Text;
                    server.NotifyObservers();

                if (!server.PozitieVadalida(this.Joc, this.jucator))
                      MessageBox.Show("Nu e barcuta");
               

            }

            if (alegere == 3)
            {
                if (label1.Text.Equals(label2.Text))
                {

                    labelpzoadv.Text = server.findAdversar(this.Joc.id,this.jucator.id).pozaleasa.ToString();

                    bool amghicit = server.AlegPozAdversar(this.Joc, this.jucator, btn.Name);
                    if (amghicit)
                    {

                        if (server.GataJoc(this.Joc) == 0)
                        {

                            MessageBox.Show("Ai nimerit");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Nu e randul tau");
                }

                server.NotifyObservers();
            }
                
            

        }

        public void LoadDTO(Object list)
        {
            Logout.BeginInvoke(new UpdateCallback(this.UpdateForm), new object[] { Logout, (String)list });
        
        }

        public delegate void UpdateCallback(Button Form, String list);



        private void UpdateForm(Button Form, string list)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 1; i <= 16; i++)
            {
                Button b = addButton(i, Color.Green);

                flowLayoutPanel1.Controls.Add(b);
                b.Click += new EventHandler(this.buttonDoubleClick);


            }




            label2.Text = server.getListiduri(this.Joc)[server.getRand(this.Joc)].ToString();


            if (server.GataJoc(this.Joc)!=0)
            {
                MessageBox.Show("A castigat" + server.GataJoc(this.Joc));
                this.Hide();
                server.RemoveObserver(this);
                logForm.Show();
            }




            //  label2.Text=server.LaRand(this.Joc).ToString();





        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            if (server.GetListaStandBy().Count == 2)
            {

                Joc jocnou = server.creareJoc();

                this.Joc = jocnou;



                List<IObserver> observers = (List<IObserver>)server.AlegereJucatori();

                List<Jucator> list = new List<Jucator>();

                foreach (var ob in observers)
                {
                    MainForm mainForm = (MainForm)ob;
                    mainForm.Joc = jocnou;
                    list.Add(mainForm.jucator);
                }

                server.creareJocJucator(list, jocnou);

                server.NotifyObservers();
            }
            else
            {
                MessageBox.Show("Asteapta");
            }


        }

      

    
    
       
    }
}
