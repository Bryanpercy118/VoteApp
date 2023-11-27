using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoteApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegisterUser registerUser = new RegisterUser();
           
            registerUser.Show();

            //MessageBox.Show("Inicio de registro de nuevo usuario");
        }

        private void btnRegistrarCandidato_Click(object sender, EventArgs e)
        {
            RegisterCandidate registerCandidate = new RegisterCandidate();

            registerCandidate.Show();

        }
    }
}
