using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VotoService
    {
        private VotoRepository votoRepository;
        public VotoService()
        {
            votoRepository = new VotoRepository();
        }
        //Datos que vienen de la GUI pasan a Repository por aqui
        public string Guardar(Voto voto)
        {
            try
            {
                votoRepository.Guardar(voto);
                return "Se guardó la Informarción satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error de Aplicacion:" + e.Message;
            }
        }


    }
}
