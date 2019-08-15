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

        ClientCtr ctr;
        LogForm logForm;
        Juriu Jurat;
        int IdParticipant;


        public MainForm()
        {
            InitializeComponent();
          
        }

        void LoadData()
        {
            dataGridView1.DataSource = ctr.GetParticipants();
        }

        public void update()
        {
            ///  Console.WriteLine("Se schimba chestii si pe altundeva");
            LoadProbaDTO(ctr.GetParticipants());  


        }

        public void setCtr(ClientCtr ctrl,LogForm logForm)
        {
            this.ctr = ctrl;
            this.logForm = logForm;
            LoadData();
        }

        public void setJurat(string username)
        {
            Jurat = ctr.GetJuriuAfterUsername(username);
            label1.Text = Jurat.aspect;
        }


        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            // mai daca e cazul ceva iesire din joc
            logForm.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                IdParticipant = Convert.ToInt32(selectedRow.Cells["id"].Value);


            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

            
            ctr.AdaugaRezultat(IdParticipant, Convert.ToInt32(textBox1.Text), Jurat.aspect);
          //  LoadData();

            


        }

        public void LoadProbaDTO(Object list)
        {
            dataGridView1.BeginInvoke(new UpdateGridViewCallback(this.UpdateGridView), new object[] { dataGridView1, (IEnumerable<Participant>)list });
        }

        public delegate void UpdateGridViewCallback(DataGridView dataGridView, IEnumerable<Participant> list);



        private void UpdateGridView(DataGridView dataGridView, IEnumerable<Participant> list)
        {

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
         }


    }
}
