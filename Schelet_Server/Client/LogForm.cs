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
    public partial class LogForm : Form
    {

        MainForm mainForm;
        ClientCtr ctr;

        public LogForm()
        { 
            InitializeComponent();
        }

        public void set(ClientCtr ctrl, MainForm mainForm)
        {
            this.ctr = ctrl;
            this.mainForm = mainForm;
        }

        private void Login_Click(object sender, EventArgs e)
        {

            if (ctr.Login(Username_Box.Text, Password_Box.Text))
            {
                this.Hide();

                mainForm.setJurat(Username_Box.Text);
                // setezi ceva id ca sa vezi cine se logheaza in functie de User
                mainForm.Show();
            }

            else
            {
                MessageBox.Show("Nu e valid acest utilizator");
            }


        }
    }
}
