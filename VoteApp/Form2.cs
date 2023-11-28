using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoteApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnReportePartido_Click(object sender, EventArgs e)
        {
            List<Candidate> candidatos = ObtenerCandidatosDesdeArchivo();

            Dictionary<string, int> conteoPartidos = new Dictionary<string, int>();

            foreach (Candidate candidato in candidatos)
            {
                string partido = candidato.PartidoPolitico;

                if (conteoPartidos.ContainsKey(partido))
                {
                    conteoPartidos[partido]++;
                }
                else
                {
                    conteoPartidos[partido] = 1;
                }
            }

            MostrarConteoPartidosEnGrilla(conteoPartidos);
        }


        private void MostrarConteoPartidosEnGrilla(Dictionary<string, int> conteoPartidos)
        {
            
            dgvReporte.Columns.Clear(); 
            dgvReporte.Columns.Add("Partido", "Partido");
            dgvReporte.Columns.Add("CantidadCandidatos", "Cantidad de Candidatos");

            
            dgvReporte.Rows.Clear();
            foreach (var kvp in conteoPartidos)
            {
                dgvReporte.Rows.Add(
                    kvp.Key, 
                    kvp.Value 
                );
            }
        }
        

        private List<Candidate> ObtenerCandidatosDesdeArchivo()
        {
            string rutaArchivoCandidatos = "Candidatos.txt";

            if (File.Exists(rutaArchivoCandidatos))
            {
                return File.ReadLines(rutaArchivoCandidatos)
                    .Select(linea =>
                    {
                        string[] partes = linea.Split(';');
                        return new Candidate
                        {
                            Id = partes[0],
                            Nombre = partes[1],
                            Apellido = partes[2],
                            PartidoPolitico = partes[4]
                        };
                    })
                    .ToList();
            }

            return new List<Candidate>();
        }

        private void dgvReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
    }
}
