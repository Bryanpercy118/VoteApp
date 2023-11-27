using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class UserService
    {
        private UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        //Datos que vienen de la GUI pasan a Repository por aqui
        public string Guardar(User user)
        {
            try
            {
                userRepository.Guardar(user);
                return "Se guardó la Informarción satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error de Aplicacion:" + e.Message;
            }
        }




    }
}
 