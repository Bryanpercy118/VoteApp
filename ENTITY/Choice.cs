using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Choice
    {
        public DateTime FechaEleccion { get; set; }
        public List<Candidate> Candidatos { get; set; }
        public List<Voter> Votantes { get; set; }
        public Dictionary<int, int> Resultados { get; set; }
        public EstadoEleccion Estado { get; set; }

        public Choice()
        {
            Candidatos = new List<Candidate>();
            Votantes = new List<Voter>();
            Resultados = new Dictionary<int, int>();
            Estado = EstadoEleccion.Activa;
        }

      
    }
    public enum EstadoEleccion
    {
        Activa,
        Cerrada,
        OtroEstado
    }

}
