using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Voto
    {
        public Voto() { }
        
        public Voto(string cedulaVotante, string idCandidato, DateTime fechaVoto)
        {
            CedulaVotante = cedulaVotante;
            IdCandidato = idCandidato;
            FechaVoto = fechaVoto;
        }

        public string CedulaVotante { get; set; }
        public string IdCandidato { get; set; }

        public DateTime FechaVoto { get; set; }
        

    }
}
