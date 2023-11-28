using ENTITY;
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

namespace VoteApp
{
    public partial class ReporteVotos : Form
    {
        public ReporteVotos()
        {
            InitializeComponent();
            dgvReporte.Columns.Add("Nombre", "Nombre");
            dgvReporte.Columns.Add("Apellido", "Apellido");
            dgvReporte.Columns.Add("PartidoPolitico", "Partido Político");
            dgvReporte.Columns.Add("Votos", "Votos");

        }

        public class CandidatoConVotos : Candidate
        {
            public int CantidadVotos { get; set; }

            public bool PerteneceVoto(string idCandidato)
            {
                return Id == idCandidato;
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            List<CandidatoConVotos> candidatosConVotos = new List<CandidatoConVotos>();

            List<Candidate> candidatos = ObtenerCandidatosDesdeArchivo();
            List<Voto> votos = ObtenerVotosDesdeArchivo();

            foreach (Candidate candidato in candidatos)
            {
                CandidatoConVotos candidatoConVotos = new CandidatoConVotos
                {
                    Id = candidato.Id,
                    Nombre = candidato.Nombre,
                    Apellido = candidato.Apellido,
                    PartidoPolitico = candidato.PartidoPolitico
                };

                
                int cantidadVotos = votos.Count(v => candidatoConVotos.PerteneceVoto(v.IdCandidato));

                candidatoConVotos.CantidadVotos = cantidadVotos;

                candidatosConVotos.Add(candidatoConVotos);
            }

            MostrarInformeEnGrilla(candidatosConVotos);
        }


        private void MostrarInformeEnGrilla(List<CandidatoConVotos> candidatosConVotos)
        {
            dgvReporte.Rows.Clear();

            foreach (CandidatoConVotos candidatoConVoto in candidatosConVotos)
            {
                dgvReporte.Rows.Add(
                    candidatoConVoto.Nombre,
                    candidatoConVoto.Apellido,
                    candidatoConVoto.PartidoPolitico,
                    candidatoConVoto.CantidadVotos
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
                            PartidoPolitico = partes[3]
                        };
                    })
                    .ToList();
            }

            return new List<Candidate>();
        }

        private List<Voto> ObtenerVotosDesdeArchivo()
        {
            string rutaArchivoVotos = "Votos.txt";

            if (File.Exists(rutaArchivoVotos))
            {
                return File.ReadLines(rutaArchivoVotos)
                    .Select(linea =>
                    {
                        string[] partes = linea.Split(';');
                        return new Voto
                        {
                            IdCandidato = partes[1],
                            CedulaVotante = partes[2],
                            FechaVoto = DateTime.Parse(partes[2]) // Ajusta el formato según tu necesidad
                        };
                    })
                    .ToList();
            }

            return new List<Voto>();
        }

        private void btnVotantes_Click(object sender, EventArgs e)
        {
            List<Voter> votantes = ObtenerVotantesDesdeArchivo();
            MostrarVotantesEnGrilla(votantes);
        }
        private void MostrarVotantesEnGrilla(List<Voter> votantes)
        {
            dgvReporte.Columns.Add("Nombre", "Nombre");
            dgvReporte.Columns.Add("Apellido", "Apellido");
            
            dgvReporte.Rows.Clear();

            foreach (Voter votante in votantes)
            {
                dgvReporte.Rows.Add(
                    votante.Nombre,
                    votante.Identificacion
                );
            }
        }
        private List<Voter> ObtenerVotantesDesdeArchivo()
        {
            string rutaArchivoVotantes = "Voters.txt";

            if (File.Exists(rutaArchivoVotantes))
            {
                return File.ReadLines(rutaArchivoVotantes)
                    .Select(linea =>
                    {
                        string[] partes = linea.Split(';');
                        return new Voter
                        {
                            Nombre = partes[2],
                            Identificacion = partes[1]
                        };
                    })
                    .ToList();
            }

            return new List<Voter>();
        }

        private void btnReportePartido_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }
    }

}
