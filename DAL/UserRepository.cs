using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace DAL
{
    public class UserRepository
    {
        private string fileName = "Persona.txt";
        public void Guardar(User user)
        {

            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{user.Id};{user.Identificacion};{user.Nombre};{user.Apellido}");
            writer.Close();
            file.Close();
        }
    }
}
