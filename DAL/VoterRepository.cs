using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class VoterRepository
    {

        private string fileName = "Voters.txt";
        public void Guardar(Voter user)
        {

            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{user.Id};{user.Identificacion};{user.Nombre};{user.Apellido};{user.Telefono}");
            writer.Close();
            file.Close();
        }
    }
}
