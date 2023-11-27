using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace VoteApp
{
    public partial class RegisterUser : Form
    {
        private VoterService userService;
        public RegisterUser()
        {
            InitializeComponent();
            userService = new VoterService();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Voter nuevousuario = new Voter
                {
                    Id = txtDocumento.Text.Trim(),
                    Identificacion = txtDocumento.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono= txtNumero.Text.Trim(),
                };
                userService.Guardar(nuevousuario);
                DialogResult result = MessageBox.Show("Usuario almacenado correctamente. ¿Desea volver al inicio de sesión?", "Éxito", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    Form1 loguin = new Form1();
                    loguin.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario. "+ ex);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
