using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VotoRepository
    {

        private string fileName = "Votos.txt";
        public void Guardar(Voto voto)
        {

            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{voto.IdCandidato};{voto.CedulaVotante};{voto.FechaVoto}");
            writer.Close();
            file.Close();
        }
    }
}
