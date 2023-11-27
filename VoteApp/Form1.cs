using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY;

namespace VoteApp
{
    public partial class Form1 : Form
    {
        private List<Voter> usuarios;
        public Form1()
        {
            InitializeComponent();
            CargarUsuariosDesdeArchivo();
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

        private void CargarUsuariosDesdeArchivo()
        {
            usuarios = new List<Voter>();

            
            string rutaArchivo = "Voters.txt";

            
            if (File.Exists(rutaArchivo))
            {   
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(',');
                    if (partes.Length == 2)
                    {
                        usuarios.Add(new Voter
                        {
                            Nombre = partes[2],
                            Identificacion = partes[1]
                        });
                    }
                }
            }
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string identificacion = txtContraseña.Text;

            if (ValidarInicioSesion(identificacion))
            {
                MessageBox.Show("Inicio de sesión exitoso");
                Eleccion eleccion = new Eleccion();
                eleccion.Show();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }


        private bool ValidarInicioSesion(string identificacion)
        {
            string rutaArchivo = "Voters.txt";

            if (File.Exists(rutaArchivo))
            {
                var lineas = File.ReadLines(rutaArchivo);

                foreach (var linea in lineas)
                {
                    Console.WriteLine($"Línea actual: {linea}");

                    string[] partes = linea.Split(';');

                    if (partes.Length > 0 && partes[0].Trim() == identificacion.Trim())
                    {
                        Console.WriteLine("Identificación válida.");
                        return true;
                    }
                }

                Console.WriteLine("No se encontró una identificación válida.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }

            return false;
        }




    }
}
