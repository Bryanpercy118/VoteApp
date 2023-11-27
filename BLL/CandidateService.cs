using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CandidateService
    {
        private CandidateRepository userRepository;
        public CandidateService()
        {
            userRepository = new CandidateRepository();
        }

        //Datos que vienen de la GUI pasan a Repository por aqui
        public string Guardar(Candidate user)
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
