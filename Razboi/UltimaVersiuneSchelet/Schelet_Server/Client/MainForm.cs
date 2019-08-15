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
        int valoarecarte = 0;

        public int IdJucatorCautat;



        public MainForm()
        {
            InitializeComponent();
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


        public void LoadDTO(Object list)
        {
            Logout.BeginInvoke(new UpdateCallback(this.UpdateForm), new object[] { Logout, (String)list });
        
        }

        public delegate void UpdateCallback(Button Form, String list);



        private void UpdateForm(Button Form, string list)
        {
            /////// ce update se face la fiecare jucator
            ///



           // if (server.FinalJoc(this.Joc))
         //   {
//
            //    MessageBox.Show("joc incheiat");
         //   }
         //   else
         //   {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = server.getAdversari(this.Joc.id, this.jucator.id);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = true;

            if (server.TotiAuAles2(this.Joc))
            {
                dataGridView1.Columns[3].Visible = true;
            }
            else
            {
                dataGridView1.Columns[3].Visible =false;
            }
        
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            //  dataGridView1.Columns[3].Visible = false;
            //  dataGridView1.Columns[4].Visible = true;
            //   dataGridView1.Columns[5].Visible = false;
            //  dataGridView1.Columns[6].Visible = false;
            //  dataGridView1.Columns[7].Visible = false;
            //  dataGridView1.Columns[8].Visible = false;


            //  if (!server.findJucatorInJoc(this.Joc.id, this.jucator.id).carte.Equals(""))
            //  {
            if (!server.AreCarte(this.Joc, this.jucator))
                {
                    dataGridView2.DataSource = null;
                    IList<String> list_string = server.generarecartiServer(this.Joc.id);
                    dataGridView2.DataSource = list_string.Select(x => new { Value = x }).ToList();
                }
            //   }
            // dataGridView2.DataSource = server.generarecartiServer(this.Joc.id);
            label2.Text = Convert.ToString(server.getRand(this.Joc));
     //       }



            //   server.LaRand(this.Joc);

           // server.LaRand(this.Joc);



        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Joc jocnou=server.creareJoc();
            
            this.Joc = jocnou;

           
         

            List<IObserver> observers = (List<IObserver>) server.AlegereJucatori();

            List<Jucator> list = new List<Jucator>();

            foreach(var ob in observers)
            {
                MainForm mainForm = (MainForm)ob;
                mainForm.Joc = jocnou;
                list.Add(mainForm.jucator);
            }

            server.creareJocJucator(list, jocnou);
           // server.dracu(this.Joc, this.jucator);
            server.NotifyObservers();


        }

        private void AlegeButton_Click(object sender, EventArgs e)
        {
            //  Console.WriteLine("dsfsd");


            if (label2.Text.Equals(jucator.id.ToString()) || label2.Text.Equals("0") ){

                //  server.AlegeCarte(this.Joc, this.jucator, textBox1.Text);
                server.AlegeCarte(this.Joc, this.jucator, Convert.ToString(valoarecarte));

                //    server.AlegCuvant(this.Joc, this.jucator, textBox1.Text);

                server.NotifyObservers();
            }
            else
            {
                MessageBox.Show("Nu e randul tau");
            }
            
          
        }

        private void GhicesteButton_Click(object sender, EventArgs e)
        {

            //if (label1.Text.Equals(label2.Text)) { 
            //if (server.PoateGhicii(this.Joc, this.jucator.id))
            //{
            //    if (!server.EGata(Joc))
            //    {
            //        if (jucator.id != IdJucatorCautat)
            //        {
            //            char litera = (char)textBox2.Text.ToString()[0];
            //            server.GhicesteLitera(Joc, jucator, litera, IdJucatorCautat);

            //            server.NotifyObservers();
            //        }

            //        else
            //        {
            //            MessageBox.Show("Asta estit tu");
            //        }
            //    }

            //    if (server.EGata(Joc))
            //    {

            //        MessageBox.Show("A castigat" + server.CelMaiBun(Joc).idjucator);
            //        this.Hide();
            //        server.FinalJoc();
            //        // mai daca e cazul ceva iesire din joc
            //        logForm.Show();
            //    }
            //}
            //}
            //else
            //{
            //    MessageBox.Show("Asteapta sa aleaga si restul");
            //}
            

           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                IdJucatorCautat = Convert.ToInt32(selectedRow.Cells["idjucator"].Value);
              //  Console.WriteLine(IdJucatorCautat);

            }
        }

        private void RazboiButton_Click(object sender, EventArgs e)
        {
           // if (server.TotiAuAles2(this.Joc))
        //    {
                server.Concurs(this.Joc);
                server.NotifyObservers();
            if (server.FinalJoc(this.Joc))
            {
                MessageBox.Show("A castigat " + server.CelMaiBun(this.Joc));
            }
         //   }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

                valoarecarte = Convert.ToInt32(selectedRow.Cells["value"].Value);
                //  Console.WriteLine(IdJucatorCautat);

            }
        }
    }
}
