using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public  class VoterService
    {
        private VoterRepository userRepository;
        public VoterService()
        {
            userRepository = new VoterRepository();
        }
        //Datos que vienen de la GUI pasan a Repository por aqui
        public string Guardar(Voter user)
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
