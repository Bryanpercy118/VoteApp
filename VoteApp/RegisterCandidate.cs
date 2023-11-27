using BLL;
using ENTITY;
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
    public partial class RegisterCandidate : Form
    {
        private CandidateService candidateService;

        public RegisterCandidate()
        {
            InitializeComponent();
            candidateService = new CandidateService();
        }

        private void btnRegistrarCandidato_Click(object sender, EventArgs e)
        {
            try
            {
                Candidate nuevousuario = new Candidate
                {
                    Id = txtDocumento.Text.Trim(),
                    Identificacion = txtDocumento.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    PartidoPolitico=cmboPartido.SelectedItem.ToString(),

                };
                candidateService.Guardar(nuevousuario);
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
                MessageBox.Show($"Error al guardar el usuario. " + ex);
            }

        }
    }
}
