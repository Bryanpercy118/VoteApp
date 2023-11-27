using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class CandidateRepository
    {
        private string fileName = "Candidatos.txt";
        
        public void Guardar(Candidate user)
        {
            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{user.Id};{user.Identificacion};{user.Nombre};{user.Apellido};{user.PartidoPolitico}");
            writer.Close();
            file.Close();
        }

    }
}
