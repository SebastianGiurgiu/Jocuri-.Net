using Schelet_Server;
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
        MyServer server;

        public LogForm()
        { 
            InitializeComponent();
        }

        public void set(MyServer server, MainForm mainForm)
        {
            this.server = server;
            this.mainForm = mainForm;
        }

        private void Login_Click(object sender, EventArgs e)
        {

            if (server.login(Username_Box.Text, Password_Box.Text))
            {
                this.Hide();
                Jucator jucator = server.findJucator(Username_Box.Text);
                mainForm.setJucator(jucator);
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
