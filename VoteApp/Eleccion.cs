using BLL;
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
using iTextSharp;
using System.Xml.Linq;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace VoteApp
{
    public partial class Eleccion : Form
    {
        private VotoService votoService;

        private string identificacionUsuario; // Añade un campo para almacenar la identificación
        public Eleccion(string identificacion)
        {
            InitializeComponent();
            CargarCandidatosDesdeArchivo();
            identificacionUsuario = identificacion; 
            votoService = new VotoService();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CargarCandidatosDesdeArchivo()
        {
            string rutaArchivo = "Candidatos.txt";

            if (File.Exists(rutaArchivo))
            {
                var candidatos = new List<Candidate>();

                var lineas = File.ReadLines(rutaArchivo);

                foreach (var linea in lineas)
                {
                    string[] partes = linea.Split(';');

                    if (partes.Length >= 3) 
                    {
                        var candidato = new Candidate
                        {
                            PartidoPolitico= partes[4],
                            Id = partes[0],
                            Identificacion = partes[1],
                            Nombre = partes[2],
                            Apellido = partes[3]
                        };

                        candidatos.Add(candidato);
                    }
                }
                
                dtaElecciones.DataSource = candidatos;
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }

        private void btnRegistrarVoto_Click(object sender, EventArgs e)
        {

            if (dtaElecciones.SelectedRows.Count > 0)
            {
                string idCandidatoSeleccionado = dtaElecciones.SelectedRows[0].Cells["Id"].Value.ToString();
                Voto nuevoVoto = new Voto(idCandidatoSeleccionado.ToString(), identificacionUsuario.ToString(), DateTime.Now);
                votoService.Guardar(nuevoVoto);
                MessageBox.Show("Voto registrado exitosamente");
                
                this.Close();
                
                Form1 form1 = new Form1();
                form1.Show();
                //GenerarPdf(nuevoVoto);
            }
            else
            {
                MessageBox.Show("Selecciona un candidato en la grilla antes de registrar el voto");
            }
        }
        private void GenerarPdf(Voto voto)
        {

            string rutaPdf = $"Voto_{voto.IdCandidato}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

            // Crear un documento PDF
            using (var writer = new PdfWriter(rutaPdf))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    // Crear un documento PDF básico con iTextSharp
                    var document = new Document(pdf);

                    // Agregar información del voto al documento
                    document.Add(new Paragraph($"Voto registrado el {voto.FechaVoto}"));
                    document.Add(new Paragraph($"Id del candidato: {voto.IdCandidato}"));
                    document.Add(new Paragraph($"Identificación del votante: {voto.CedulaVotante}"));

                    // Puedes agregar más información si es necesario

                    // Cerrar el documento
                    document.Close();
                }
            }

            MessageBox.Show($"PDF generado exitosamente: {rutaPdf}");
        }
    }
}
